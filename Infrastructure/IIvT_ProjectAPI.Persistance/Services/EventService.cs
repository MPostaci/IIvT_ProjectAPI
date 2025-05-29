using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Abstractions.Storage;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.DTOs.Event;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using IIvT_ProjectAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class EventService : IEventService
    {
        readonly IMapper _mapper;
        readonly IEventReadRepository _eventReadRepository;
        readonly IEventWriteRepository _eventWriteRepository;
        readonly IAddressService _addressService;
        readonly ICategoryService _categoryService;
        readonly UserManager<AppUser> _userManager;
        readonly IStorageService _storageService;
        readonly IEventMediaFileWriteRepository _eventMediaFileWriteRepository;

        public EventService(IMapper mapper, IEventReadRepository eventReadRepository, IEventWriteRepository eventWriteRepository, IAddressService addressService, ICategoryService categoryService, UserManager<AppUser> userManager, IStorageService storageService, IEventMediaFileWriteRepository eventMediaFileWriteRepository)
        {
            _mapper = mapper;
            _eventReadRepository = eventReadRepository;
            _eventWriteRepository = eventWriteRepository;
            _addressService = addressService;
            _categoryService = categoryService;
            _userManager = userManager;
            _storageService = storageService;
            _eventMediaFileWriteRepository = eventMediaFileWriteRepository;
        }

        public async Task<PagedResponse<ListEventDto>> GetAllEvents(PagedRequest pagedRequest)
        {
            var query = _eventReadRepository.GetAll(false);

            return await query.ToPagedListAsync<Event ,ListEventDto>(_mapper, pagedRequest);

        }

        private Guid ParseId(string id)
        {
            if (!Guid.TryParse(id, out Guid parsedEventId))
                throw new ArgumentException("Invalid id format.", nameof(id));
            return parsedEventId;
        }

        public async Task<ListEventDto> GetEventByIdAsync(string eventId)
        {
            var eventEntity = await _eventReadRepository.GetByIdAsync(eventId, false);
            if (eventEntity == null)
                throw new KeyNotFoundException($"Event with ID {eventId} not found.");
            return _mapper.Map<ListEventDto>(eventEntity);
        }

        public async Task<PagedResponse<ListEventDto>> GetEventsByCategory(string categoryId, PagedRequest pagedRequest)
        {
            var query = _eventReadRepository.GetAll(false)
                .Where(e => e.CategoryId == ParseId(categoryId));
            return await query.ToPagedListAsync<Event, ListEventDto>(_mapper, pagedRequest);
        }

        public async Task<PagedResponse<ListEventDto>> GetEventsByDate(DateTime startDate, DateTime endDate, PagedRequest pagedRequest)
        {
            var query = _eventReadRepository.GetAll(false)
                .Where(e => e.StartDate.Date >= startDate.Date && e.EndDate.Date <= endDate.Date);
            return await query.ToPagedListAsync<Event, ListEventDto>(_mapper, pagedRequest);
        }

        public async Task<PagedResponse<ListEventDto>> GetEventsByLocation(string city, string? district, string? neighborhood, PagedRequest pagedRequest)
        {
            var query = _eventReadRepository.GetAll(false)
                .Include(e => e.Address)
                .Where(e => e.Address.City.Name == city)
                .Where(e => string.IsNullOrEmpty(district) || e.Address.District.Name == district)
                .Where(e => string.IsNullOrEmpty(neighborhood) || e.Address.Neighborhood.Name == neighborhood);

            return await query.ToPagedListAsync<Event, ListEventDto>(_mapper, pagedRequest);
        }

        public async Task<PagedResponse<ListEventDto>> GetEventsByPublisher(string publisherId, PagedRequest pagedRequest)
        {
            var query = _eventReadRepository.GetAll(false)
                .Where(e => e.PublisherId == publisherId);
            return await query.ToPagedListAsync<Event, ListEventDto>(_mapper, pagedRequest);
        }

        public async Task<ListEventDto> CreateEventAsync(CreateEventDto createEventDto)
        {
            Guid addressId = Guid.Empty;

            if (
                !createEventDto.Location.GetType().GetProperties()
                    .Where(pi => pi.PropertyType == typeof(string))
                    .Select(pi => (string)pi.GetValue(createEventDto.Location))
                    .Any(value => string.IsNullOrEmpty(value))
                )
            {
                addressId = (await _addressService.AddAddressAsync(createEventDto.Location)).Id;
            }
            else if (!string.IsNullOrEmpty(createEventDto.AddressId))
                addressId = (await _addressService.GetAddressByIdAsync(createEventDto.AddressId)).Id;


            var newEventId = Guid.NewGuid();

            Event newEvent = new();
            newEvent.Id = newEventId;

            if (addressId != Guid.Empty)
            {
                newEvent.AddressId = addressId;
            }

            var user = await _userManager.FindByIdAsync(createEventDto.PublisherId);

            newEvent.Publisher = user;

            newEvent.CategoryId = Guid.Parse((await _categoryService.GetByIdCategory(createEventDto.CategoryId)).Id);

            await _eventWriteRepository.AddAsync(_mapper.Map(createEventDto, newEvent));

            var listevent = _mapper.Map<ListEventDto>(newEvent);
            return listevent;
        }

        public async Task<bool> DeleteEventAsync(string eventId)
        {
            var eventEntity = await _eventReadRepository.GetByIdAsync(eventId)
                ?? throw new KeyNotFoundException($"Event with ID {eventId} not found.");

            eventEntity.IsDeleted = true;

            return _eventWriteRepository.Update(eventEntity);
        }

        public async Task<ListEventDto> UpdateEventAsync(UpdateEventDto updateEventDto)
        {
            var eventEntity = await _eventReadRepository.GetByIdAsync(updateEventDto.Id)
                ?? throw new KeyNotFoundException($"Event with ID {updateEventDto.Id} not found.");

            _mapper.Map(updateEventDto, eventEntity);

            if (!string.IsNullOrEmpty(updateEventDto.CategoryId))
            {
                var category = await _categoryService.GetByIdCategory(updateEventDto.CategoryId) 
                    ?? throw new KeyNotFoundException($"Category with ID {updateEventDto.CategoryId} not found.");
                eventEntity.CategoryId = Guid.Parse(category.Id);
            }
            if (!string.IsNullOrEmpty(updateEventDto.AddressId))
            {
                var address = await _addressService.GetAddressByIdAsync(updateEventDto.AddressId)
                    ?? throw new KeyNotFoundException($"Address with ID {updateEventDto.AddressId} not found.");
                eventEntity.AddressId = address.Id;
            }
            if (!string.IsNullOrEmpty(updateEventDto.PublisherId))
            {
                var user = await _userManager.FindByIdAsync(updateEventDto.PublisherId) 
                    ?? throw new KeyNotFoundException($"User with ID {updateEventDto.PublisherId} not found.");
                eventEntity.Publisher = user;
            }

            _eventWriteRepository.Update(eventEntity);

            return _mapper.Map<ListEventDto>(eventEntity);
        }

        public async Task<bool> UploadFile(IFormFileCollection files, string eventId)
        {
            if (!Guid.TryParse(eventId, out Guid parsedEventId))
                throw new ArgumentException("Invalid eventId format.", nameof(eventId));

            List<(string fileName, string pathOrContainerName)> uploadedFiles = await _storageService.UploadAsync("announcement-files", files);

            List<EventMediaFile> annFile = new List<EventMediaFile>();

            foreach (var file in uploadedFiles)
            {
                annFile.Add(new EventMediaFile
                {
                    Id = Guid.NewGuid(),
                    FileName = file.fileName,
                    Path = file.pathOrContainerName,
                    FileTpye = _storageService.GetFileType(file.fileName),
                    EventId = parsedEventId,
                    Storage = _storageService.StorageName,
                });
            }

            return await _eventMediaFileWriteRepository.AddRangeAsync(annFile);
        }
    }
}
