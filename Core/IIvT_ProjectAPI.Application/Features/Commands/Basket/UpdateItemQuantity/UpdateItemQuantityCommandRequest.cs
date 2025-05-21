using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Basket.UpdateItemQuantity
{
    public class UpdateItemQuantityCommandRequest : IRequest<UpdateItemQuantityCommandResponse>, ICommandRequest
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}