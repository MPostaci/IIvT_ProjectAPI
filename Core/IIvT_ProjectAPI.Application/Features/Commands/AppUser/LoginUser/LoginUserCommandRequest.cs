using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>, ICommandRequest
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
}