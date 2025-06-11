using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.EventFile.DeleteEventFile
{
    public class DeleteEventFileCommandHandler : IRequestHandler<DeleteEventFileCommandRequest, DeleteEventFileCommandResponse>
    {
        readonly IEventService _eventService;

        public DeleteEventFileCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<DeleteEventFileCommandResponse> Handle(DeleteEventFileCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _eventService.RemoveFileAsync(request.EventId, request.FileId);

            return new()
            {
                Success = result,
                Message = result ? "File deleted successfully" : "File could not deleted. Please try again later"
            };
        }
    }
}
