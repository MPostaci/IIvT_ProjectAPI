using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetAllOrdersWithDetails
{
    public class GetAllOrdersWithDetailsQueryRequest : PagedRequest, IRequest<PagedResponse<ListOrderWithDetailsDto>>, IQueryRequest
    {
    }
}