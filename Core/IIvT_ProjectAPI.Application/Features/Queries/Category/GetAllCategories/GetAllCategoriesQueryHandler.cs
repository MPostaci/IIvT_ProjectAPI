using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Category;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, PagedResponse<ListCategoryDto>>
    {
        readonly ICategoryService _categoryService;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<PagedResponse<ListCategoryDto>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllCategories(request);
        }
    }
}
