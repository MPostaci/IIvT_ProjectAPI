using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Basket.UpdateItemQuantity
{
    public class UpdateItemQuantityCommandRequest : IRequest<UpdateItemQuantityCommandResponse>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}