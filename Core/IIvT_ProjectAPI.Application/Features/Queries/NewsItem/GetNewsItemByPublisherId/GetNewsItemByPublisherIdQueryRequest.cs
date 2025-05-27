using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByPublisherId
{
    public class GetNewsItemByPublisherIdQueryRequest : PagedRequest, IRequest<PagedResponse<GetNewsItemByPublisherIdQueryResponse>>, IQueryRequest
    {
        public string Id { get; set; }
    }
}