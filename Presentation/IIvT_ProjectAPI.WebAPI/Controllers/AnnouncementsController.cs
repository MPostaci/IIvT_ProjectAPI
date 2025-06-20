﻿using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
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
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAnnouncements([FromQuery] GetAllAnnouncementsCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("by-id")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnnouncementById([FromQuery] GetAnnouncementsByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("by-categoryId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnnouncementsByCategoryId([FromQuery] GetAnnouncementByCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("by-publisherId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAnnouncementsByPublisherId([FromQuery] GetAnnouncementsByPublisherCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Announcements, ActionType.Writing, "Create Announcement")]
        public async Task<IActionResult> CreateAnnouncement([FromForm] CreateAnnouncementCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok("File uploaded successfully");
        }

        [HttpPut]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Announcements, ActionType.Updating, "Update Announcement")]
        public async Task<IActionResult> UpdateAnnouncement([FromForm] UpdateAnnouncementCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstants.Announcements, ActionType.Reading, "Delete Announcement")]
        public async Task<IActionResult> DeleteAnnouncement([FromRoute] DeleteAnnouncementCommandRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
