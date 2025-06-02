using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.OrderStatus.CreateOrderStatus
{
    public class CreateOrderStatusCommandHandler : IRequestHandler<CreateOrderStatusCommandRequest, CreateOrderStatusCommandResponse>
    {
        private readonly IOrderStatusService _orderStatusService;
        public CreateOrderStatusCommandHandler(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }
        public async Task<CreateOrderStatusCommandResponse> Handle(CreateOrderStatusCommandRequest request, CancellationToken cancellationToken)
        {
            var orderStatus = await _orderStatusService.CreateOrderStatusAsync(request.Name, request.Description);

            return new CreateOrderStatusCommandResponse
            {
                Id = orderStatus.Id.ToString(),
                Name = orderStatus.Name,
                Description = orderStatus.Description
            };
        }
    }
}
