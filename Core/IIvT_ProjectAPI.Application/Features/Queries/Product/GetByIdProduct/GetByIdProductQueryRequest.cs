using IIvT_ProjectAPI.Application.DTOs.Product;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<ListProductDto>
    {
        public string Id { get; set; }
    }
}