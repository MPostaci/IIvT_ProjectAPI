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
        public async Task<IActionResult> GetEvents([FromQuery] GetAllEventsQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("location")]
        public async Task<IActionResult> GetEventsByLocation([FromQuery] GetEventsByLocationQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{EventId}")]
        public async Task<IActionResult> GetEventById([FromRoute] GetEventByIdQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetEventsByCategory([FromQuery] GetEventsByCategoryQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("date")]
        public async Task<IActionResult> GetEventsByDate([FromQuery] GetEventsByDateQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("publisher")]
        public async Task<IActionResult> GetEventsByPublisher([FromQuery] GetEventsByPublisherQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEvent([FromBody] UpdateEventCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadEventFile([FromForm] UploadEventFileCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}
