using IIvT_ProjectAPI.Application.Features.Commands.OrderStatus.CreateOrderStatus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IIvT_ProjectAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusesController : ControllerBase
    {
        readonly IMediator _mediator;

        public OrderStatusesController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
