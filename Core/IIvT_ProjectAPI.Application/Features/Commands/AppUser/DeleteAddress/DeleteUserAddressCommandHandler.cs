using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.DeleteAddress
{
    public class DeleteUserAddressCommandHandler : IRequestHandler<DeleteUserAddressCommandRequest, DeleteUserAddressCommandResponse>
    {
        readonly IUserService _userService;

        public DeleteUserAddressCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<DeleteUserAddressCommandResponse> Handle(DeleteUserAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.DeleteUserAddressAsync(request.AddressId);

            return new()
            {
                Success = result,
                Message = result ? "Address Deleted Successfully" : "Something went wrong"
            };
        }
    }
}
