using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs;
using IIvT_ProjectAPI.Application.DTOs.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            BaseResponseDto response = await _userService.CreateAsync(new CreateUserDto()
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
            });

            return new()
            {
                Status = response.Status,
                Message = response.Message
            };
        }
    }
}
