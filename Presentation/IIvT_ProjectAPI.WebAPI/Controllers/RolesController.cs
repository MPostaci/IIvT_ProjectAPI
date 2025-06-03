using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.Features.Commands.Role.CreateRole;
using IIvT_ProjectAPI.Application.Features.Commands.Role.DeleteRole;
using IIvT_ProjectAPI.Application.Features.Commands.Role.UpdateRole;
using IIvT_ProjectAPI.Application.Features.Queries.Role.GetAllRoles;
using IIvT_ProjectAPI.Application.Features.Queries.Role.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Roles, ActionType.Reading, "Get All Roles")]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetAllRolesQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{Id}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Roles, ActionType.Reading, "Get Role By Id")]
        public async Task<IActionResult> GetRoleById([FromRoute] GetRoleByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(new { response.id, response.name });
        }

        [HttpPost]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Roles, ActionType.Writing, "Create Role")]
        public async Task<IActionResult> CreateRole([FromQuery] CreateRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Roles, ActionType.Updating, "Update Role")]
        public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{RoleIdOrName}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Roles, ActionType.Deleting, "Delete Role")]
        public async Task<IActionResult> DeleteRole([FromRoute] DeleteRoleCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
