using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrderWithDetailById
{
    public class GetOrderWithDetailByIdQueryHandler : IRequestHandler<GetOrderWithDetailByIdQueryRequest, ListOrderWithDetailsDto>
    {
        readonly IOrderService _orderService;

        public GetOrderWithDetailByIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<ListOrderWithDetailsDto> Handle(GetOrderWithDetailByIdQueryRequest request, CancellationToken cancellationToken)
            => await _orderService.GetOrderWithDetailById(request.Id);
    }
}
