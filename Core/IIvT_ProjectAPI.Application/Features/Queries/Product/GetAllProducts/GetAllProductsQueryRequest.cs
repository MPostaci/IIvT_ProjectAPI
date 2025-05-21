using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Product;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryRequest : PagedRequest, IRequest<PagedResponse<ListProductDto>>, IQueryRequest
    {
    }
}