using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Abstractions.Storage;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.NewsItem;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
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
    public class NewsItemService : INewsItemService
    {
        readonly IMapper _mapper;
        readonly INewsItemReadRepository _newsItemReadRepository;
        readonly INewsItemWriteRepository _newsItemWriteRepository;
        readonly INewsItemMediaFileReadRepository _newsItemMediaFileReadRepository;
        readonly INewsItemMediaFileWriteRepository _newsItemMediaFileWriteRepository;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly ICategoryService _categoryService;
        readonly IStorageService _storageService;

        public NewsItemService(INewsItemReadRepository newsItemReadRepository, INewsItemWriteRepository newsItemWriteRepository, INewsItemMediaFileReadRepository newsItemMediaFileReadRepository, INewsItemMediaFileWriteRepository newsItemMediaFileWriteRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, ICategoryService categoryService, IStorageService storageService)
        {
            _newsItemReadRepository = newsItemReadRepository;
            _newsItemWriteRepository = newsItemWriteRepository;
            _newsItemMediaFileReadRepository = newsItemMediaFileReadRepository;
            _newsItemMediaFileWriteRepository = newsItemMediaFileWriteRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _categoryService = categoryService;
            _storageService = storageService;
        }


        private async Task<string> GetContextUserId()
        {
            string? username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

            return (await _userManager.FindByNameAsync(username)).Id;
        }

        public async Task<PagedResponse<ListNewsItemDto>> GetAllNewsItemsAsync(PagedRequest pagedRequest)
        {
            var query = _newsItemReadRepository.GetAll(false);

            return await query.ToPagedListAsync<NewsItem, ListNewsItemDto>(_mapper, pagedRequest);
        }

        public async Task<ListNewsItemDto> GetNewsItemByIdAsync(string id)
        {
            var query = _newsItemReadRepository.Table
                .Where(n => n.Id == Guid.Parse(id))
                .Include(n => n.Category)
                .Include(n => n.Publisher)
                .Include(n => n.Files);

            var item = await query.FirstOrDefaultAsync();

            return _mapper.Map<ListNewsItemDto>(item);

        }

        public Task<PagedResponse<ListNewsItemDto>> GetNewsItemsByCategoryIdAsync(string categoryId, PagedRequest pagedRequest)
        {
            var query = _newsItemReadRepository.GetWhere(n => n.CategoryId == Guid.Parse(categoryId), false);

            return query.ToPagedListAsync<NewsItem, ListNewsItemDto>(_mapper, pagedRequest);
        }

        public Task<PagedResponse<ListNewsItemDto>> GetNewsItemsByPublisherIdAsync(string publisherId, PagedRequest pagedRequest)
        {
            var query = _newsItemReadRepository.GetWhere(n => n.PublisherId == publisherId, false);

            return query.ToPagedListAsync<NewsItem, ListNewsItemDto>(_mapper, pagedRequest);
        }

        public async Task<ListNewsItemDto> CreateNewsItemAsync(CreateNewsItemDto createNewsItemDto)
        {
            var newsItem = _mapper.Map<NewsItem>(createNewsItemDto);

            string userId = await GetContextUserId();
            newsItem.PublisherId = userId;


            bool result = await _newsItemWriteRepository.AddAsync(newsItem);

            if (createNewsItemDto.Files != null && createNewsItemDto.Files.Any())
            {
                await UploadFilesAsync(newsItem.Id.ToString(), createNewsItemDto.Files);
            }

            var category = await _categoryService.GetByIdCategory(newsItem.CategoryId.ToString());

            newsItem.Category.Name = category.Name;

            newsItem.Category.Description = category.Description;

            if (result)
            {
                return _mapper.Map<ListNewsItemDto>(newsItem);
            }

            throw new Exception("Failed to create news item. Please try again later.");
        }

        public async Task<bool> DeleteNewsItemAsync(string id)
        {
            return await _newsItemWriteRepository.RemoveAsync(id);
        }

        public async Task<ListNewsItemDto> UpdateNewsItemAsync(UpdateNewsItemDto updateNewsItemDto)
        {
            var item = await _newsItemReadRepository.GetByIdAsync(updateNewsItemDto.Id)
                ?? throw new Exception("News item not found.");

            _mapper.Map(updateNewsItemDto, item);

            _newsItemWriteRepository.Update(item);

            return _mapper.Map<ListNewsItemDto>(item);

        }

        public async Task<bool> UploadFilesAsync(string newsItemId, IFormFileCollection files)
        {
            List<(string fileName, string pathOrContainerName)> uploadedFiles = await _storageService.UploadAsync("newsItem-files", files);

            List<NewsItemMediaFile> items = new();

            foreach (var (fileName, pathOrContainerName) in uploadedFiles)
            {
                items.Add(new NewsItemMediaFile
                {
                    Id = Guid.NewGuid(),
                    FileName = fileName,
                    FileTpye = _storageService.GetFileType(fileName),
                    NewsItemId = Guid.Parse(newsItemId),
                    Path = pathOrContainerName,
                    Storage = _storageService.StorageName,
                });
            }

            await _newsItemMediaFileWriteRepository.AddRangeAsync(items);

            return true;
        }

        public async Task<bool> RemoveFileAsync(string newsItemId, string fileId)
        {

            var file = _newsItemMediaFileReadRepository.GetWhere(f => f.Id == Guid.Parse(fileId) && f.NewsItemId == Guid.Parse(newsItemId)).FirstOrDefault()
                ?? throw new Exception("File not found.");

            _newsItemMediaFileWriteRepository.Remove(file);

            string filePath = $"newsItem-files/{file.FileName}";

            await _storageService.DeleteAsync(filePath);

            return true;
        }

        public async Task<bool> ChangeShowcaseFile(string newsItemId, string fileId)
        {
            var showcase = await _newsItemMediaFileReadRepository.GetSingleAsync(f => f.Showcase == true && f.NewsItemId == Guid.Parse(newsItemId));


            if (showcase != null)
            {
                showcase.Showcase = false;
                _newsItemMediaFileWriteRepository.Update(showcase);
            }

            var file = _newsItemMediaFileReadRepository.GetWhere(f => f.Id == Guid.Parse(fileId) && f.NewsItemId == Guid.Parse(newsItemId)).FirstOrDefault()
                ?? throw new Exception("File not found.");

            file.Showcase = true;

            _newsItemMediaFileWriteRepository.Update(file);

            return true;
        }
    }
}
