using IIvT_ProjectAPI.Application.Features.Commands.Announcement.CreateAnnouncement;
using IIvT_ProjectAPI.Application.Features.Commands.Announcement.DeleteAnnouncement;
using IIvT_ProjectAPI.Application.Features.Commands.Announcement.UpdateAnnouncement;
using IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAllAnnouncements;
using IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAnnouncementsByCategory;
using IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAnnouncementsById;
using IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAnnouncementsByPublisher;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AnnouncementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncements([FromQuery] GetAllAnnouncementsCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("by-id")]
        public async Task<IActionResult> GetAnnouncementById([FromQuery] GetAnnouncementsByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("by-categoryId")]
        public async Task<IActionResult> GetAnnouncementsByCategoryId([FromQuery] GetAnnouncementByCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("by-publisherId")]
        public async Task<IActionResult> GetAnnouncementsByPublisherId([FromQuery] GetAnnouncementsByPublisherCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> CreateAnnouncement([FromForm] CreateAnnouncementCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok("File uploaded successfully");
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> UpdateAnnouncement([FromForm] UpdateAnnouncementCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> DeleteAnnouncement([FromRoute] DeleteAnnouncementCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
