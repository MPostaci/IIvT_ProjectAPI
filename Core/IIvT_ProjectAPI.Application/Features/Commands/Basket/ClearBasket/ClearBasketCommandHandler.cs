using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Basket.ClearBasket
{
    public class ClearBasketCommandHandler : IRequestHandler<ClearBasketCommandRequest, ClearBasketCommandResponse>
    {
        readonly IBasketService _basketService;

        public ClearBasketCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<ClearBasketCommandResponse> Handle(ClearBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _basketService.ClearBasketAsync();

            return new()
            {
                State = result,
                Message = result ? "Basket cleared successfully." : "Failed to clear basket.",
            };
        }
    }
}
