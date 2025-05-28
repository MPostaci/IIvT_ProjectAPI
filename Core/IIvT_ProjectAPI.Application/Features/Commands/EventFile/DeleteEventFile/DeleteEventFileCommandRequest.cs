using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.EventFile.DeleteEventFile
{
    public class DeleteEventFileCommandRequest : IRequest<DeleteEventFileCommandResponse>, ICommandRequest
    {
    }
}