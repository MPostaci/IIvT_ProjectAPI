using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _categoryService.DeleteCategory(request.Id);

            return new DeleteCategoryCommandResponse
            {
                IsSuccess = result,
                Message = result ? "Category deleted successfully." : "Failed to delete category."
            };
        }
    }
}
