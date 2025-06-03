using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrdersWithDetailByOrderStatus
{
    public class GetOrdersWithDetailByOrderStatusQueryHandler : IRequestHandler<GetOrdersWithDetailByOrderStatusQueryRequest, PagedResponse<ListOrderWithDetailsDto>>
    {
        readonly IOrderService _orderService;

        public GetOrdersWithDetailByOrderStatusQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<PagedResponse<ListOrderWithDetailsDto>> Handle(GetOrdersWithDetailByOrderStatusQueryRequest request, CancellationToken cancellationToken)
            => await _orderService.GetOrderByOrderStatus(request.OrderStatusId, new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize });
    }
}
