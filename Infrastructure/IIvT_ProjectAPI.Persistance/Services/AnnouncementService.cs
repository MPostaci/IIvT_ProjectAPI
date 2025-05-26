using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Abstractions.Storage;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using IIvT_ProjectAPI.Application.Exceptions;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Domain.Entities.Common;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        readonly IAnnouncementReadRepository _announcementReadRepository;
        readonly IAnnouncementWriteRepository _announcementWriteRepository;
        readonly IAnnouncementMediaFileWriteRepository _announcementMediaFileWriteRepository;
        readonly IAnnouncementMediaFileReadRepository _announcementMediaFileReadRepository;
        readonly UserManager<AppUser> _userManager;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IStorageService _storageService;
        readonly IMapper _mapper;

        public AnnouncementService(IAnnouncementReadRepository announcementReadRepository, IAnnouncementWriteRepository announcementWriteRepository, UserManager<AppUser> userManager, IAnnouncementMediaFileWriteRepository announcementMediaFileWriteRepository, IHttpContextAccessor httpContextAccessor, IStorageService storageService, IMapper mapper, IAnnouncementMediaFileReadRepository announcementMediaFileReadRepository)
        {
            _announcementReadRepository = announcementReadRepository;
            _announcementWriteRepository = announcementWriteRepository;
            _userManager = userManager;
            _announcementMediaFileWriteRepository = announcementMediaFileWriteRepository;
            _httpContextAccessor = httpContextAccessor;
            _storageService = storageService;
            _mapper = mapper;
            _announcementMediaFileReadRepository = announcementMediaFileReadRepository;
        }

        private async Task<AppUser> ContextUser()
        {
            var username = _httpContextAccessor.HttpContext?.User.Identity?.Name
                ?? throw new NotFoundUserException();

            AppUser user = await _userManager.FindByNameAsync(username);

            if (user == null) throw new NotFoundUserException();
            return user;
        }

        public async Task<PagedResponse<ListAnnouncementDto>> GetAllAnnouncementsAsync(PagedRequest request)
        {
            var query = _announcementReadRepository.GetAll(false);

            var result = await query.ToPagedListAsync<Announcement, ListAnnouncementDto>(_mapper, request);

            return result;
        }

        public async Task<PagedResponse<ListAnnouncementDto>> GetAnnouncementsByIdAsync(PagedRequest request, string id)
        {
            var query = _announcementReadRepository.GetAll(false).Where(x => x.Id == Guid.Parse(id));

            var result = await query.ToPagedListAsync<Announcement, ListAnnouncementDto>(_mapper, request);

            return result;
        }

        public async Task<PagedResponse<ListAnnouncementDto>> GetAnnouncementsByCategoryAsync(PagedRequest request, string categoryId)
        {
            var query = _announcementReadRepository.GetAll(false).Where(x => x.CategoryId == Guid.Parse(categoryId));

            var result = await query.ToPagedListAsync<Announcement, ListAnnouncementDto>(_mapper, request);

            return result;
        }

        public async Task<PagedResponse<ListAnnouncementDto>> GetAnnouncementsByPublisherAsync(PagedRequest request, string publisherId)
        {
            var query = _announcementReadRepository.GetAll(false).Where(x => x.PublisherId == publisherId);

            var result = await query.ToPagedListAsync<Announcement, ListAnnouncementDto>(_mapper, request);

            return result;
        }

        public async Task<bool> CreateAnnouncement(CreateAnnouncementDto createAnnouncementDto)
        {
            var user = await ContextUser();

            Guid id = Guid.NewGuid();

            await _announcementWriteRepository.AddAsync(new Announcement
            {
                Id = id,
                Content = createAnnouncementDto.Content,
                Description = createAnnouncementDto.Description,
                Title = createAnnouncementDto.Title,
                CategoryId = Guid.Parse(createAnnouncementDto.CategoryId),
                PublisherId = user.Id,
                File = await UploadFile(createAnnouncementDto.File, id),
            });

            return true;
        }

        public async Task<bool> DeleteAnnouncement(string id)
        {
            var announcement = await _announcementReadRepository.GetByIdAsync(id)
                ?? throw new NotFoundAnnouncementException();

            announcement.IsDeleted = true;

            return true;
        }

        public async Task<bool> UpdateAnnouncement(UpdateAnnouncementDto updateAnnouncementDto)
        {
            var announcement = await _announcementReadRepository.GetByIdAsync(updateAnnouncementDto.Id)
                ?? throw new NotFoundAnnouncementException();


            _mapper.Map(updateAnnouncementDto, announcement);

            if (updateAnnouncementDto.File != null)
            {
                var mediaFile = await _announcementMediaFileReadRepository.GetWhere(x => x.AnnouncementId == announcement.Id).FirstOrDefaultAsync();
                if (mediaFile != null)
                {
                    // Delete the old file
                    await _storageService.DeleteAsync(mediaFile.Path);
                    await _announcementMediaFileWriteRepository.RemoveAsync(mediaFile.Id.ToString());
                }

                // Create a new FormFileCollection and add the file
                FormFileCollection fileCollection = new()
                {
                    updateAnnouncementDto.File
                };
                announcement.File = await UploadFile(fileCollection, announcement.Id);
            }

            _announcementWriteRepository.Update(announcement);

            return true;
        }

        private async Task<AnnouncementMediaFile> UploadFile(IFormFileCollection file, Guid annId)
        {
            if (file == null || file.Count == 0)
                throw new FileNotFoundException("File not found");

            (string fileName, string pathOrContainerName) = (await _storageService.UploadAsync("announcement-files", file)).FirstOrDefault();

            AnnouncementMediaFile annFile;
            await _announcementMediaFileWriteRepository.AddAsync(annFile = new AnnouncementMediaFile
            {
                Id = Guid.NewGuid(),
                FileName = fileName,
                Path = pathOrContainerName,
                FileTpye = _storageService.GetFileType(file.FirstOrDefault().FileName),
                AnnouncementId = annId,
                Storage = _storageService.StorageName
            });

            return annFile;
        }
    }
}
