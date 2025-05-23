using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.ProductImage.GetProductImages
{
    public class GetProductImagesQueryRequest : IRequest<List<GetProductImagesQueryResponse>>, IQueryRequest
    {
        public string Id { get; set; }
    }
}