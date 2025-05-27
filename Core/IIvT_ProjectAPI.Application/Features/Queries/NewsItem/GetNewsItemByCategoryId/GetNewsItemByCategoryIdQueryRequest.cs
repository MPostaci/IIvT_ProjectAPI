using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByCategoryId
{
    public class GetNewsItemByCategoryIdQueryRequest : PagedRequest, IRequest<PagedResponse<GetNewsItemByCategoryIdQueryResponse>>, IQueryRequest
    {
        public string CategoryId { get; set; }
    }
}