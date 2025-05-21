using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Basket.GetUserBasket
{
    public class GetUserBasketQueryRequest : IRequest<ListBasketDto>, IQueryRequest
    {
    }
}
