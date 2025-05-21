using IIvT_ProjectAPI.Application.Features.Commands.Basket.AddItemToBasket;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.ClearBasket;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.RemoveItemFromBasket;
using IIvT_ProjectAPI.Application.Features.Commands.Basket.UpdateItemQuantity;
using IIvT_ProjectAPI.Application.Features.Queries.Basket.GetUserBasket;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BasketsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket([FromQuery] GetUserBasketQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToBasket([FromQuery] AddItemToBasketCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemInBasket([FromQuery] UpdateItemQuantityCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveItemFromBasket([FromQuery] RemoveItemFromBasketCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearBasket([FromRoute] ClearBasketCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
