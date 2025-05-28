using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Event.CreateEvent
{
    public class CreateEventCommandRequest : IRequest<ListEventDto>, ICommandRequest
    {
    }
}