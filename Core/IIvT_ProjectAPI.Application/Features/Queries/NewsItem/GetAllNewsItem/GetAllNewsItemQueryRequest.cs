using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetAllNewsItem
{
    public class GetAllNewsItemQueryRequest : PagedRequest, IRequest<PagedResponse<GetAllNewsItemQueryResponse>>, IQueryRequest
    {
    }
}