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
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Baskets, ActionType.Reading, "Get Logged In User's Basket")]
        public async Task<IActionResult> GetBasket([FromQuery] GetUserBasketQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Baskets, ActionType.Writing, "Add Item To Basket")]
        public async Task<IActionResult> AddItemToBasket([FromQuery] AddItemToBasketCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Baskets, ActionType.Updating, "Update Item Quantity")]
        public async Task<IActionResult> UpdateItemInBasket([FromQuery] UpdateItemQuantityCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Baskets, ActionType.Deleting, "Remove Item From Basket")]
        public async Task<IActionResult> RemoveItemFromBasket([FromQuery] RemoveItemFromBasketCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("clear")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Baskets, ActionType.Deleting, "Clear The Basket")]
        public async Task<IActionResult> ClearBasket([FromRoute] ClearBasketCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
