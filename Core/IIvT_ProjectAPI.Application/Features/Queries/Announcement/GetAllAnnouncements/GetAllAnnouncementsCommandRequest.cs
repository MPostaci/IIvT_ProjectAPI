using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAllAnnouncements
{
    public class GetAllAnnouncementsCommandRequest : PagedRequest, IRequest<PagedResponse<ListAnnouncementDto>>, IQueryRequest
    {
    }
}