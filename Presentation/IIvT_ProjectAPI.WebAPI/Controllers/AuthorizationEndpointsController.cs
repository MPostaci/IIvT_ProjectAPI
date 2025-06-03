using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleToEndpoint;
using IIvT_ProjectAPI.Application.Features.Queries.AuthorizationEndpoint.GetRolesForEndpoint;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("get-roles")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.AuthorizationEndpoints, ActionType.Reading, "Get Roles By Menu's Endpoint")]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesForEndpointQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("assign-roles")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.AuthorizationEndpoints, ActionType.Writing, "Assing Role To Endpoint")]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleToEndpointCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
