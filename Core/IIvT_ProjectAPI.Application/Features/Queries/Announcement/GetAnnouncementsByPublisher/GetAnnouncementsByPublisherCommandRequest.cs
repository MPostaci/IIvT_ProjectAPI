using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAnnouncementsByPublisher
{
    public class GetAnnouncementsByPublisherCommandRequest : PagedRequest, IRequest<PagedResponse<ListAnnouncementDto>>
    {
        public string PublisherId { get; set; }
    }
}