using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.User;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.AppUser.GetAllUsers
{
    public class GetAllUsersQueryRequest : PagedRequest, IRequest<PagedResponse<ListUserDto>>, IQueryRequest
    {
    }
}