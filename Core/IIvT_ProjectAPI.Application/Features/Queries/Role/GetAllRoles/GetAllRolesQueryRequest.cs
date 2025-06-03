using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Role.GetAllRoles
{
    public class GetAllRolesQueryRequest : PagedRequest, IRequest<PagedResponse<IDictionary<string, string>>>, IQueryRequest
    {
    }
}