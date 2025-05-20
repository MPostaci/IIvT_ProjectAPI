using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Product;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Product.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, PagedResponse<ListProductDto>>
    {
        readonly IProductService _productService;

        public GetAllProductsQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<PagedResponse<ListProductDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProductsAsync(request);
        }
    }
}
