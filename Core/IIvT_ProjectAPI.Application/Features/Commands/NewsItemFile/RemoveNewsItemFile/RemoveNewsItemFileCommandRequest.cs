using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItemFile.RemoveNewsItemFile
{
    public class RemoveNewsItemFileCommandRequest : IRequest<RemoveNewsItemFileCommandResponse>, ICommandRequest
    {
        public string NewsItemId { get; set; }
        public string FileId { get; set; }
    }
}