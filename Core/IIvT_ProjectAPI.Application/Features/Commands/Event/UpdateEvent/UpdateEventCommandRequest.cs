using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Event.UpdateEvent
{
    public class UpdateEventCommandRequest : IRequest<UpdateEventCommandResponse>, ICommandRequest
    {
    }
}