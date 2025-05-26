using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            CreateCategoryDto createCategoryDto = new()
            {
                Name = request.Name,
                Description = request.Description,
                ContentType = request.ContentType,
            };
            var result = await _categoryService.CreateCategory(createCategoryDto);

            return new CreateCategoryCommandResponse
            {
                IsSuccess = result,
                Message = result ? "Category created successfully." : "Failed to create category."
            };
        }
    }
}
