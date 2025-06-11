using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Event.DeleteEvent
{
    public class DeleteEventCommandRequest : IRequest<DeleteEventCommandResponse>, ICommandRequest
    {
        public string EventId { get; set; }
    }
}