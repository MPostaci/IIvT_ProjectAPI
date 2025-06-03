using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.OrderStatus.CreateOrderStatus
{
    public class CreateOrderStatusCommandRequest : IRequest<CreateOrderStatusCommandResponse>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
