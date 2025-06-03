using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.DTOs.Event;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IIvT_ProjectAPI.Application.Features.Commands.Event.CreateEvent
{
    public class CreateEventCommandRequest : IRequest<ListEventDto>, ICommandRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CategoryId { get; set; }
        public string PublisherId { get; set; }
        public string? AddressId { get; set; }
        public CreateAddressDto? Location { get; set; }
    }
}