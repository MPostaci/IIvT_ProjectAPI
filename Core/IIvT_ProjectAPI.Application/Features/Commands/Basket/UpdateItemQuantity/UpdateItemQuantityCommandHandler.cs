using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Basket.UpdateItemQuantity
{
    public class UpdateItemQuantityCommandHandler : IRequestHandler<UpdateItemQuantityCommandRequest, UpdateItemQuantityCommandResponse>
    {
        readonly IBasketService _basketService;

        public UpdateItemQuantityCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<UpdateItemQuantityCommandResponse> Handle(UpdateItemQuantityCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _basketService.UpdateItemQuantityAsync(request.ProductId, request.Quantity);

            return new()
            {
                State = result,
                Message = result ? "Item quantity updated successfully." : "Failed to update item quantity.",
            };
        }
    }
}
