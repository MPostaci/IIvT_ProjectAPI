using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.AuthorizationEndpoint.GetRolesForEndpoint
{
    public class GetRolesForEndpointQueryHandler : IRequestHandler<GetRolesForEndpointQueryRequest, GetRolesForEndpointQueryResponse>
    {
        readonly IAuthorizationEndpointService _authEndpointService;

        public GetRolesForEndpointQueryHandler(IAuthorizationEndpointService authEndpointService)
        {
            _authEndpointService = authEndpointService;
        }

        public async Task<GetRolesForEndpointQueryResponse> Handle(GetRolesForEndpointQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await _authEndpointService.GetRolesForEndpointAsync(
                menuName: request.MenuName,
                code: request.Code
                );

            return new()
            {
                Roles = roles
            };
        }
    }
}
