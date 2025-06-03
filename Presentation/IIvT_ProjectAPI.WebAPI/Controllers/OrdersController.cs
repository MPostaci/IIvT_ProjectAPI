using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.Features.Commands.Order.CreateOrder;
using IIvT_ProjectAPI.Application.Features.Queries.Order.GetAllOrdersWithDetails;
using IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrdersWithDetailByOrderStatus;
using IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrdersWithDetailByUserId;
using IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrderWithDetailById;
using IIvT_ProjectAPI.Application.Features.Queries.Order.GetOrderWithDetailByOrderCode;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Orders, ActionType.Reading, "Get All Orders With Details")]
        public async Task<IActionResult> GetAllOrdersWithDetails([FromQuery] GetAllOrdersWithDetailsQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Orders, ActionType.Reading, "Get Order With Details By Id")]
        public async Task<IActionResult> GetOrderWithDetailsById([FromRoute] GetOrderWithDetailByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("user-id")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Orders, ActionType.Reading, "Get Orders With Details By User Id")]
        public async Task<IActionResult> GetOrdersWithDetailsByUserId([FromQuery] GetOrdersWithDetailByUserIdQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("contextUser-id")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Orders, ActionType.Reading, "Get Orders With Details By Logged In User")]
        public async Task<IActionResult> GetOrdersWithDetailsByContextUserId([FromQuery] GetOrdersWithDetailByUserIdQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("order-code")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Orders, ActionType.Reading, "Get Orders With Details By Order Code")]
        public async Task<IActionResult> GetOrderWithDetailsByOrderCode([FromQuery] GetOrderWithDetailByOrderCodeQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("order-status")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Orders, ActionType.Reading, "Get Orders With Details By Order Status")]
        public async Task<IActionResult> GetOrdersWithDetailsByOrderStatus([FromQuery] GetOrdersWithDetailByOrderStatusQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Orders, ActionType.Writing, "Create Order")]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
