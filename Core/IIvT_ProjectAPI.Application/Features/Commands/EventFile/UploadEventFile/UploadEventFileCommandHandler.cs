using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.EventFile.UploadEventFile
{
    public class UploadEventFileCommandHandler : IRequestHandler<UploadEventFileCommandRequest, UploadEventFileCommandResponse>
    {
        readonly IEventService _eventService;

        public UploadEventFileCommandHandler(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<UploadEventFileCommandResponse> Handle(UploadEventFileCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _eventService.UploadFile(request.Files, request.EventId);

            return new()
            {
                Success = result,
                Message = result ? "File(s) uploaded successfully." : "File upload failed.",
            };
        }
    }
}
