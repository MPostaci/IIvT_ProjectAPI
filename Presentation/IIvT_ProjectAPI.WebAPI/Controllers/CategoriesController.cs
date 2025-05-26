using IIvT_ProjectAPI.Application.Features.Commands.Category.CreateCategory;
using IIvT_ProjectAPI.Application.Features.Commands.Category.DeleteCategory;
using IIvT_ProjectAPI.Application.Features.Commands.Category.UpdateCategory;
using IIvT_ProjectAPI.Application.Features.Queries.Category.GetAllCategories;
using IIvT_ProjectAPI.Application.Features.Queries.Category.GetByIdCategory;
using IIvT_ProjectAPI.Application.Features.Queries.Category.GetContentTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class CategoriesController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetByIdCategoryQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("content-types")]
        public async Task<IActionResult> GetContentTypes([FromQuery] GetContentTypesQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
