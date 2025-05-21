using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketCommandRequest : IRequest<RemoveItemFromBasketCommandResponse>
    {
        public string ProductId { get; set; }
    }
}