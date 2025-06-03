using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQueryRequest, ListEventDto>
    {
        private readonly IEventService _eventService;

        public GetEventByIdQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<ListEventDto> Handle(GetEventByIdQueryRequest request, CancellationToken cancellationToken)
            => await _eventService.GetEventByIdAsync(request.EventId);
    }
}
