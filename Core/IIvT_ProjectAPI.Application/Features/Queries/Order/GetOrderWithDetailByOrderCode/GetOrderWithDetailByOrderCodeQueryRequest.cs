using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrderWithDetailByOrderCode
{
    public class GetOrderWithDetailByOrderCodeQueryRequest : IRequest<ListOrderWithDetailsDto>, IQueryRequest
    {
        public string OrderCode { get; set; }
    }
}