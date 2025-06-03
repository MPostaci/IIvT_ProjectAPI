using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetAllOrdersWithDetails
{
    public class GetAllOrdersWithDetailsQueryHandler : IRequestHandler<GetAllOrdersWithDetailsQueryRequest, PagedResponse<ListOrderWithDetailsDto>>
    {
        readonly IOrderService _orderService;

        public GetAllOrdersWithDetailsQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<PagedResponse<ListOrderWithDetailsDto>> Handle(GetAllOrdersWithDetailsQueryRequest request, CancellationToken cancellationToken)
            => await _orderService.GetAllOrdersWithDetails(request);
    }
}
