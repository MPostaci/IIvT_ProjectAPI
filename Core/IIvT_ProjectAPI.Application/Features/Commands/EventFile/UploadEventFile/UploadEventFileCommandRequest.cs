using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IIvT_ProjectAPI.Application.Features.Commands.EventFile.UploadEventFile
{
    public class UploadEventFileCommandRequest : IRequest<UploadEventFileCommandResponse>, ICommandRequest
    {
        public string EventId { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}