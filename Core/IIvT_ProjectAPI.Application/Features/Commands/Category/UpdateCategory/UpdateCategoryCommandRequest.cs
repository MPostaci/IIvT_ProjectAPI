using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ContentType { get; set; }
    }
}