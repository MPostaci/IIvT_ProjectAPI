using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketCommandRequest : IRequest<RemoveItemFromBasketCommandResponse>, ICommandRequest
    {
        public string ProductId { get; set; }
    }
}