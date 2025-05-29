using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByPublisher
{
    public class GetEventsByPublisherQueryHandler : IRequestHandler<GetEventsByPublisherQueryRequest, PagedResponse<ListEventDto>>
    {
        private readonly IEventService _eventService;

        public GetEventsByPublisherQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<PagedResponse<ListEventDto>> Handle(GetEventsByPublisherQueryRequest request, CancellationToken cancellationToken)
            => await _eventService.GetEventsByPublisher(
                request.PublisherId,
                new() { PageNumber = request.PageNumber, PageSize = request.PageSize }
            );
    }
}
