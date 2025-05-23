using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IAnnouncementService
    {
        Task<PagedResponse<ListAnnouncementDto>> GetAllAnnouncementsAsync(PagedRequest request);
        Task<PagedResponse<ListAnnouncementDto>> GetAnnouncementsByIdAsync(PagedRequest request, string id);
        Task<PagedResponse<ListAnnouncementDto>> GetAnnouncementsByCategoryAsync(PagedRequest request, string categoryId);
        Task<PagedResponse<ListAnnouncementDto>> GetAnnouncementsByPublisherAsync(PagedRequest request, string publisherId);

        Task CreateAnnouncement(CreateAnnouncementDto createAnnouncementDto);
    }
}
