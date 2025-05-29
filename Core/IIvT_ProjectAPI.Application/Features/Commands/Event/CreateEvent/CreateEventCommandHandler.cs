using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Event.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest, ListEventDto>
    {
        readonly IMapper _mapper;
        readonly IEventService _eventService;

        public CreateEventCommandHandler(IMapper mapper, IEventService eventService)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        public async Task<ListEventDto> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
            => await _eventService.CreateEventAsync(_mapper.Map<CreateEventDto>(request));
    }
}
