using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrdersWithDetailByUserId
{
    public class GetOrdersWithDetailByUserIdQueryHandler : IRequestHandler<GetOrdersWithDetailByUserIdQueryRequest, PagedResponse<ListOrderWithDetailsDto>>
    {
        readonly IOrderService _orderService;

        public GetOrdersWithDetailByUserIdQueryHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<PagedResponse<ListOrderWithDetailsDto>> Handle(GetOrdersWithDetailByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            if(request.UserId == null)
                return await _orderService.GetOrdersWithDetailByUserId(new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize });
            else
                return await _orderService.GetOrdersWithDetailByUserId(request.UserId, new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize});
            
        }
    }
}
