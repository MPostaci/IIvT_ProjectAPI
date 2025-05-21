using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Basket.RemoveItemFromBasket
{
    public class RemoveItemFromBasketCommandHandler : IRequestHandler<RemoveItemFromBasketCommandRequest, RemoveItemFromBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public RemoveItemFromBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<RemoveItemFromBasketCommandResponse> Handle(RemoveItemFromBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _basketService.RemoveItemFromBasket(request.ProductId);

            return new()
            {
                State = result,
                Message = result ? "Item removed from basket successfully." : "Failed to remove item from basket.",
            };
        }
    }
}
