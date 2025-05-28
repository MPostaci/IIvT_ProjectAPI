using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetAllEvents
{
    public class GetAllEventsQueryRequest : PagedRequest, IRequest<PagedResponse<ListEventDto>>, IQueryRequest
    {
    }
}