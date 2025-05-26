using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Domain.Entities;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>, ICommandRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ContentType { get; set; }
    }
}