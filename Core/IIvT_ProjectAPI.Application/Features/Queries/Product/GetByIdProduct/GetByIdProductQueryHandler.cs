using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, ListProductDto>
    {
        readonly IProductService _productService;

        public GetByIdProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ListProductDto> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            return await _productService.GetByIdProductAsync(request.Id);
        }
    }
}
