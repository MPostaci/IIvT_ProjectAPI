using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleToEndpoint
{
    public class AssignRoleToEndpointCommandRequest : IRequest<AssignRoleToEndpointCommandResponse>, ICommandRequest
    {
        public string MenuName { get; set; }
        public string Code { get; set; }
        public string[] Roles { get; set; }
    }
}