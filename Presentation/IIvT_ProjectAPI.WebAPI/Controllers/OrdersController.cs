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
    [Authorize(AuthenticationSchemes = "Admin")]
    public class OrdersController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdersWithDetails([FromQuery] GetAllOrdersWithDetailsQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOrdersWithDetailsById([FromRoute] GetOrderWithDetailByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("user-id")]
        public async Task<IActionResult> GetOrdersWithDetailsByUserId([FromQuery] GetOrdersWithDetailByUserIdQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("contextUser-id")]
        public async Task<IActionResult> GetOrdersWithDetailsByContextUserId([FromQuery] GetOrdersWithDetailByUserIdQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("order-code")]
        public async Task<IActionResult> GetOrderWithDetailsByOrderCode([FromQuery] GetOrderWithDetailByOrderCodeQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("order-status")]
        public async Task<IActionResult> GetOrdersWithDetailsByOrderStatus([FromQuery] GetOrdersWithDetailByOrderStatusQueryRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
