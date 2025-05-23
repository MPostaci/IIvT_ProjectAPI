using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.ProductImage.RemoveProductImage
{
    public class RemoveProductImageCommandRequest : IRequest<RemoveProductImageCommandResponse>, ICommandRequest
    {
        public string Id { get; set; }
    }
}