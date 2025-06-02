using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Order;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, ListOrderDto>
    {
        readonly IOrderService _orderService;
        readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public Task<ListOrderDto> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
            => _orderService.CreateOrderAsync(_mapper.Map<CreateOrderDto>(request));
    }
}
