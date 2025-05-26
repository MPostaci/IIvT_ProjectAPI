using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, ListCategoryDto>
    {
        readonly ICategoryService _categoryService;

        public GetByIdCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<ListCategoryDto> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetByIdCategory(request.Id);
        }
    }
}
