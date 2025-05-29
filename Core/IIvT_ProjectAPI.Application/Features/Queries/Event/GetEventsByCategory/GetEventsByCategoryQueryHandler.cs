using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByCategory
{
    public class GetEventsByCategoryQueryHandler : IRequestHandler<GetEventsByCategoryQueryRequest, PagedResponse<ListEventDto>>
    {
        private readonly IEventService _eventService;

        public GetEventsByCategoryQueryHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<PagedResponse<ListEventDto>> Handle(GetEventsByCategoryQueryRequest request, CancellationToken cancellationToken)
            => await _eventService.GetEventsByCategory(
                request.CategoryId,
                new() { PageNumber = request.PageNumber, PageSize = request.PageSize }
            );
    }
}
