using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemById
{
    public class GetNewsItemByIdQueryRequest : IRequest<GetNewsItemByIdQueryResponse>, IQueryRequest
    {
        public string Id { get; set; }
    }
}