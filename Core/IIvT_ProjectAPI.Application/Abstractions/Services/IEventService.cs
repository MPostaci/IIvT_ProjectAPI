using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IEventService
    {
        Task<PagedResponse<ListEventDto>> GetAllEvents(PagedRequest pagedRequest);
        Task<ListEventDto> GetEventByIdAsync(string eventId);
        Task<PagedResponse<ListEventDto>> GetEventsByCategory(string categoryId, PagedRequest pagedRequest);
        Task<PagedResponse<ListEventDto>> GetEventsByDate(DateTime startDate, DateTime endDate, PagedRequest pagedRequest);
        Task<PagedResponse<ListEventDto>> GetEventsByPublisher(string publisherId, PagedRequest pagedRequest);
        Task<PagedResponse<ListEventDto>> GetEventsByLocation(string city, string? district, string? neighborhood, PagedRequest pagedRequest);

        /// <summary>
        /// Creates a new event.
        /// </summary>
        /// <param name="createEventDto">Data Transfer Object containing event details.</param>
        /// <returns>ListEventDto</returns>
        Task<ListEventDto> CreateEventAsync(CreateEventDto createEventDto);
        Task<bool> DeleteEventAsync(string eventId);
        Task<ListEventDto> UpdateEventAsync(UpdateEventDto updateEventDto);
        Task<bool> UploadFile(IFormFileCollection files, string eventId);
    }
}
