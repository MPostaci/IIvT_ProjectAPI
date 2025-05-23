using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.ProductImage.ChangeShowcaseIamge
{
    public class ChangeShowcaseImageCommandRequest : IRequest<ChangeShowcaseImageCommandResponse>
    {
        public string Id { get; set; }
    }
}