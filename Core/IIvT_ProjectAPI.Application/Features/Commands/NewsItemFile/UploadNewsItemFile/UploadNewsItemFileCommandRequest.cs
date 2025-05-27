using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItemFile.UploadNewsItemFile
{
    public class UploadNewsItemFileCommandRequest : IRequest<UploadNewsItemFileCommandResponse>, ICommandRequest
    {
        public string NewsItemId { get; set; }
        public IFormFileCollection File { get; set; }
        // Additional properties can be added here if needed
    }
}