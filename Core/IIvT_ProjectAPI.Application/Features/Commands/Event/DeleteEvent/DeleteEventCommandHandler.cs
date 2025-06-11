using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Event.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommandRequest, DeleteEventCommandResponse>
    {
        readonly IEventService _eventService;

        public DeleteEventCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<DeleteEventCommandResponse> Handle(DeleteEventCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _eventService.DeleteEventAsync(request.EventId);

            return new()
            {
                Success = result,
                Message = result ? "Event deleted successfully" : "Event could not deleted. Please try again later"
            };
        }
    }
}
