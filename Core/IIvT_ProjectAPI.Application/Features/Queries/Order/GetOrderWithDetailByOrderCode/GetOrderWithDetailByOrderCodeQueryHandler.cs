using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrderWithDetailByOrderCode
{
    public class GetOrderWithDetailByOrderCodeQueryHandler : IRequestHandler<GetOrderWithDetailByOrderCodeQueryRequest, ListOrderWithDetailsDto>
    {
        readonly IOrderService _orderService;

        public GetOrderWithDetailByOrderCodeQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<ListOrderWithDetailsDto> Handle(GetOrderWithDetailByOrderCodeQueryRequest request, CancellationToken cancellationToken)
            => await _orderService.GetOrderByOrderCode(request.OrderCode);
    }
}
