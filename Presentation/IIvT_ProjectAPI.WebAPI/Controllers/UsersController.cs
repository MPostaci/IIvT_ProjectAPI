using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.Features.Commands.AppUser.AssingRoleToUser;
using IIvT_ProjectAPI.Application.Features.Commands.AppUser.CreateUser;
using IIvT_ProjectAPI.Application.Features.Commands.AppUser.LoginUser;
using IIvT_ProjectAPI.Application.Features.Commands.AppUser.RefreshTokenLogin;
using IIvT_ProjectAPI.Application.Features.Queries.AppUser.GetAllUsers;
using IIvT_ProjectAPI.Application.Features.Queries.AppUser.GetRolesToUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Users, ActionType.Reading, "Get All Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("{UserIdOrName}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Users, ActionType.Reading, "Get Roles To User")]
        public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);

            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {
            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);

            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Users, ActionType.Writing, "Assign Roles To User")]
        public async Task<IActionResult> AssignRolesToUser([FromBody] AssignRoleToUserCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
