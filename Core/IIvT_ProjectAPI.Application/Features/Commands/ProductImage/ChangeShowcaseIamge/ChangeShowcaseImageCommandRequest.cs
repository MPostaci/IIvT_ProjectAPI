using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.ProductImage.ChangeShowcaseIamge
{
    public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>, ICommandRequest
    {
        public string Id { get; set; }
    }
}