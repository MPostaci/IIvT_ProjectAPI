using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.EventFile.UploadEventFile
{
    public class UploadEventFileCommandRequest : IRequest<UploadEventFileCommandResponse>, ICommandRequest
    {
    }
}