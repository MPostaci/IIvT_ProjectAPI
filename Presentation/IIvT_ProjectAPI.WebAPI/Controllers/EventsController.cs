using IIvT_ProjectAPI.Application.Common.Constants;
using IIvT_ProjectAPI.Application.Common.Security;
using IIvT_ProjectAPI.Application.Features.Commands.Event.CreateEvent;
using IIvT_ProjectAPI.Application.Features.Commands.Event.UpdateEvent;
using IIvT_ProjectAPI.Application.Features.Commands.EventFile.UploadEventFile;
using IIvT_ProjectAPI.Application.Features.Queries.Event.GetAllEvents;
using IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventById;
using IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByCategory;
using IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByDate;
using IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByLocation;
using IIvT_ProjectAPI.Application.Features.Queries.Event.GetEventsByPublisher;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Reading, "Get All Events")]
        public async Task<IActionResult> GetEvents([FromQuery] GetAllEventsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("location")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Reading, "Get All Events By Location")]
        public async Task<IActionResult> GetEventsByLocation([FromQuery] GetEventsByLocationQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{EventId}")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Reading, "Get Event By EventId")]
        public async Task<IActionResult> GetEventById([FromRoute] GetEventByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("category")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Reading, "Get All Events By Category")]
        public async Task<IActionResult> GetEventsByCategory([FromQuery] GetEventsByCategoryQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("date")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Reading, "Get All Events By Date")]
        public async Task<IActionResult> GetEventsByDate([FromQuery] GetEventsByDateQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("publisher")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Reading, "Get All Events By Publisher Id")]
        public async Task<IActionResult> GetEventsByPublisher([FromQuery] GetEventsByPublisherQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Writing, "Create Event")]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Updating, "Update Event")]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("upload-file")]
        [Authorize]
        [AuthorizeDefinition(AuthorizeDefinitionConstans.Events, ActionType.Deleting, "Delete Event")]
        public async Task<IActionResult> UploadEventFile([FromForm] UploadEventFileCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}
