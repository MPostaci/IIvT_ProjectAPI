using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.DTOs.Order;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest : IRequest<ListOrderDto>, ICommandRequest
    {
        public string? ShippingAddressId { get; set; }
        public string? BillingAddressId { get; set; }
        public CreateAddressDto? ShippingAddress { get; set; }
        public CreateAddressDto? BillingAddress { get; set; }
    }
}