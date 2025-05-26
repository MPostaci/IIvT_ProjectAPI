using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Category.GetContentTypes
{
    public class GetContentTypesQueryRequest : IRequest<GetContentTypesQueryResponse>, IQueryRequest
    {
    }
}