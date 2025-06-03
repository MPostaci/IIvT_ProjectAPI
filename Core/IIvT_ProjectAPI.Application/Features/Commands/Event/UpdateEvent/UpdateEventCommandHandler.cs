using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Event.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommandRequest, ListEventDto>
    {
        readonly IEventService _eventService;
        readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        public async Task<ListEventDto> Handle(UpdateEventCommandRequest request, CancellationToken cancellationToken)
            => await _eventService.UpdateEventAsync(_mapper.Map<UpdateEventDto>(request));

    }
}
