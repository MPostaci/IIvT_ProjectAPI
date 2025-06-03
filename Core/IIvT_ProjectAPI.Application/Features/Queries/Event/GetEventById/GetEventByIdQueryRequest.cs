using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventById
{
    public class GetEventByIdQueryRequest : IRequest<ListEventDto>, IQueryRequest
    {
        public string EventId { get; set; }
    }
}