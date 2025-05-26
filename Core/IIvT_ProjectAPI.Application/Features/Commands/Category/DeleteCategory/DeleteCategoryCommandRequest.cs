using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>, ICommandRequest
    {
        public string Id { get; set; }
    }
}