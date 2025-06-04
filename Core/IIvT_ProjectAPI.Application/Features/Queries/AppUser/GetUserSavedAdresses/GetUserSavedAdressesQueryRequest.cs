using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.AppUser.GetUserSavedAdresses
{
    public class GetUserSavedAdressesQueryRequest : PagedRequest, IRequest<PagedResponse<GetAddressDto>>
    {
    }
}