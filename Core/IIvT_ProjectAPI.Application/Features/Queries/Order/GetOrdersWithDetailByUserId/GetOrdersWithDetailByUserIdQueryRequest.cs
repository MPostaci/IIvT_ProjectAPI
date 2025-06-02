using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrdersWithDetailByUserId
{
    public class GetOrdersWithDetailByUserIdQueryRequest : PagedRequest, IRequest<PagedResponse<ListOrderWithDetailsDto>>, IQueryRequest
    {
        public string? UserId { get; set; }
    }
}