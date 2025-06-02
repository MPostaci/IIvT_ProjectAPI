using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.OrderDetail.CreateOrderDetail
{
    public class CreateOrderDetailCommandRequest : IRequest<ListOrderDetailDto>, ICommandRequest
    {
    }
}