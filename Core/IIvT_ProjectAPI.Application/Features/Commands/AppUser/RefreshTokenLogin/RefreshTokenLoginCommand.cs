using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs;
using IIvT_ProjectAPI.Application.DTOs.Token;
using IIvT_ProjectAPI.Application.Exceptions;
using IIvT_ProjectAPI.Application.Util;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        readonly IUserService _userService;

        public RefreshTokenLoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            (IdentityResult result, TokenDto? token) = await _userService.RefreshTokenAsync(request.RefreshToken);

            if (result.Succeeded && token != null)
                return new()
                {
                    Token = token
                };

            throw new InvalidOperationException("Couldn't refresh token");
        }
    }
}
