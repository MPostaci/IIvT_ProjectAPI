using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByDate
{
    public class GetEventsByDateQueryHandler : IRequestHandler<GetEventsByDateQueryRequest, PagedResponse<ListEventDto>>
    {
        private readonly IEventService _eventService;

        public GetEventsByDateQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<PagedResponse<ListEventDto>> Handle(GetEventsByDateQueryRequest request, CancellationToken cancellationToken)
            => await _eventService.GetEventsByDate(
                request.StartDate,
                request.EndDate,
                new() { PageNumber = request.PageNumber, PageSize = request.PageSize }
            );
    }
}
