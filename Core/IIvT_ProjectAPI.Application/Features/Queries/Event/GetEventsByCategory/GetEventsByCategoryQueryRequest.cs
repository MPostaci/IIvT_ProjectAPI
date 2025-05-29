using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByCategory
{
    public class GetEventsByCategoryQueryRequest : PagedRequest, IRequest<PagedResponse<ListEventDto>>, IQueryRequest
    {
        public string CategoryId { get; set; }
    }
}