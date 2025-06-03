using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.AssingRoleToUser
{
    public class AssignRoleToUserCommandRequest : IRequest<AssignRoleToUserCommandResponse>, ICommandRequest
    {
        public string UserId { get; set; }
        public string[] Roles { get; set; }
    }
}