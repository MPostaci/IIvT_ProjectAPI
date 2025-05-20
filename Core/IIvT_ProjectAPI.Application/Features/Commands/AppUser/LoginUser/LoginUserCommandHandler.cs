using I = IIvT_ProjectAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIvT_ProjectAPI.Application.Abstractions.Token;
using IIvT_ProjectAPI.Application.Exceptions;
using IIvT_ProjectAPI.Application.DTOs.Token;
using IIvT_ProjectAPI.Application.Abstractions.Services;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IUserService _userService;

        public LoginUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            TokenDto token = await _userService.LoginAsync(request.UserNameOrEmail, request.Password);

            return new()
            {
                Token = token
            };
        }
    }
}
