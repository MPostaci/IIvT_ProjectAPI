using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrderWithDetailById
{
    public class GetOrderWithDetailByIdQueryRequest : IRequest<ListOrderWithDetailsDto>, IQueryRequest
    {
        public string Id { get; set; }
    }
}