using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.AppUser.GetUserSavedAdresses
{
    public class GetUserSavedAdressesQueryHandler : IRequestHandler<GetUserSavedAdressesQueryRequest, PagedResponse<GetAddressDto>>
    {
        readonly IUserService _userService;

        public GetUserSavedAdressesQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<PagedResponse<GetAddressDto>> Handle(GetUserSavedAdressesQueryRequest request, CancellationToken cancellationToken)
            => await _userService.GetUserSavedAdresses(request);
    }
}
