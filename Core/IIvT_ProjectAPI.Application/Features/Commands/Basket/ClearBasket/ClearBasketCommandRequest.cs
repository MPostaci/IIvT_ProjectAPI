using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Basket.ClearBasket
{
    public class ClearBasketCommandRequest : IRequest<ClearBasketCommandResponse>, ICommandRequest
    {
    }
}