using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Event.UpdateEvent
{
    public class UpdateEventCommandRequest : IRequest<ListEventDto>, ICommandRequest
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? AddressId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CategoryId { get; set; }
        public string? PublisherId { get; set; }
    }
}