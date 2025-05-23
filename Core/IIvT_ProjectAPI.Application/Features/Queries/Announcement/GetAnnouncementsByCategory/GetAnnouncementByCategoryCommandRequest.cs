using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAnnouncementsByCategory
{
    public class GetAnnouncementByCategoryCommandRequest : PagedRequest, IRequest<PagedResponse<ListAnnouncementDto>>, IQueryRequest
    {
        public string CategoryId { get; set; }
    }
}