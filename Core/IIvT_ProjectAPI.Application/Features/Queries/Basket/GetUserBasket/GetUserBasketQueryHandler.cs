using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Basket.GetUserBasket
{
    public class GetUserBasketQueryHandler : IRequestHandler<GetUserBasketQueryRequest, ListBasketDto>
    {
        readonly IBasketService _basketService;

        public GetUserBasketQueryHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<ListBasketDto> Handle(GetUserBasketQueryRequest request, CancellationToken cancellationToken)
        {
            return await _basketService.GetBasketAsync();
        }
    }
}
