using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.ProductImage.RemoveProductImage
{
    public class RemoveProductImageCommandRequest : IRequest<RemoveProductImageCommandResponse>
    {
        public string Id { get; set; }
    }
}