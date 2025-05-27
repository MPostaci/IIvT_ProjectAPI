using AutoMapper;
using IIvT_ProjectAPI.Application.Features.Commands.NewsItem.CreateNewsItem;
using IIvT_ProjectAPI.Application.Features.Commands.NewsItem.DeleteNewsItem;
using IIvT_ProjectAPI.Application.Features.Commands.NewsItem.UpdateNewsItem;
using IIvT_ProjectAPI.Application.Features.Commands.NewsItemFile.ChangeShowcaseImage;
using IIvT_ProjectAPI.Application.Features.Commands.NewsItemFile.RemoveNewsItemFile;
using IIvT_ProjectAPI.Application.Features.Commands.NewsItemFile.UploadNewsItemFile;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetAllNewsItem;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByCategoryId;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemById;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByPublisherId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class NewsItemsController : ControllerBase
    {
        readonly IMediator _mediator;

        public NewsItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNewsItems([FromQuery] GetAllNewsItemQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNewsItemsById([FromRoute] GetNewsItemByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("by-category")]
        public async Task<IActionResult> GetNewsItemsByCategoryId([FromQuery] GetNewsItemByCategoryIdQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("by-publisher")]
        public async Task<IActionResult> GetNewsItemsByPublisherId([FromQuery] GetNewsItemByPublisherIdQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewsItem([FromForm] CreateNewsItemCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNewsItem([FromBody] UpdateNewsItemCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteNewsItem([FromRoute] DeleteNewsItemCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadNewsItemFile([FromForm] UploadNewsItemFileCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpPut("change-showcase")]
        public async Task<IActionResult> ChangeNewsItemImageShowcase([FromQuery] ChangeShowcaseImageCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("delete-file")]
        public async Task<IActionResult> RemoveNewsItemFile([FromQuery] RemoveNewsItemFileCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
