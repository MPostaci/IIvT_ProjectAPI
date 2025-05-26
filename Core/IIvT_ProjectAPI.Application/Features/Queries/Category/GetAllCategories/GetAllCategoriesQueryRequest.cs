using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Category;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : PagedRequest, IRequest<PagedResponse<ListCategoryDto>>, IQueryRequest
    {
    }
}