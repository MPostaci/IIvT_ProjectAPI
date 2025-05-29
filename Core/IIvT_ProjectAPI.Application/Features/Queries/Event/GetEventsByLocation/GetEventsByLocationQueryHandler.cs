using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByLocation
{
    public class GetEventsByLocationQueryHandler : IRequestHandler<GetEventsByLocationQueryRequest, PagedResponse<ListEventDto>>
    {
        private readonly IEventService _eventService;

        public GetEventsByLocationQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<PagedResponse<ListEventDto>> Handle(GetEventsByLocationQueryRequest request, CancellationToken cancellationToken)
            => await _eventService.GetEventsByLocation(
                request.City, 
                request.District, 
                request.Neighborhood, 
                new() { PageNumber = request.PageNumber, PageSize = request.PageSize}
                );
    }
}
