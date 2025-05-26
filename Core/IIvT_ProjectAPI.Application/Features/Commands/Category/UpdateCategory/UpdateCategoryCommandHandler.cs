using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _categoryService.UpdateCategory(_mapper.Map<UpdateCategoryDto>(request));

            return new UpdateCategoryCommandResponse
            {
                IsSuccess = result,
                Message = result ? "Category updated successfully." : "Failed to update category."
            };
        }
    }
}
