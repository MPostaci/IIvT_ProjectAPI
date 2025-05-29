using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Event.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQueryRequest, PagedResponse<ListEventDto>>
    {
        readonly IEventService _eventService;
        readonly IMapper _mapper;

        public GetAllEventsQueryHandler(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public async Task<PagedResponse<ListEventDto>> Handle(GetAllEventsQueryRequest request, CancellationToken cancellationToken)
            => await _eventService.GetAllEvents(request);
    }
}
