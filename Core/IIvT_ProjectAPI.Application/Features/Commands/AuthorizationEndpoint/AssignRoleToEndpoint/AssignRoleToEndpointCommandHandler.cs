using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleToEndpoint
{
    public class AssignRoleToEndpointCommandHandler : IRequestHandler<AssignRoleToEndpointCommandRequest, AssignRoleToEndpointCommandResponse>
    {
        readonly IAuthorizationEndpointService _authEndpointService;

        public AssignRoleToEndpointCommandHandler(IAuthorizationEndpointService authEndpointService)
        {
            _authEndpointService = authEndpointService;
        }

        public async Task<AssignRoleToEndpointCommandResponse> Handle(AssignRoleToEndpointCommandRequest request, CancellationToken cancellationToken)
        {
            await _authEndpointService.AssignRoleToEndpointAsync(
                roles: request.Roles,
                menuName: request.MenuName,
                code: request.Code
                );

            return new()
            {
                Success = true,
                Message = "Roles assigned succesfully."
            };
        }
    }
}
