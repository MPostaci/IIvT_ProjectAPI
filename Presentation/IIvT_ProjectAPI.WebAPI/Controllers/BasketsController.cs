using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.AddItemToBasket;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.ClearBasket;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.RemoveItemFromBasket;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.UpdateItemQuantity;
using IIvT_ProjectAPI.Application.Features.Queries.Basket.GetUserBasket;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBasket([FromQuery] GetUserBasketQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddItemToBasket([FromQuery] AddItemToBasketCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateItemInBasket([FromQuery] UpdateItemQuantityCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> RemoveItemFromBasket([FromQuery] RemoveItemFromBasketCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("clear")]
        [Authorize]
        public async Task<IActionResult> ClearBasket([FromRoute] ClearBasketCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
