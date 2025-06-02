using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class OrderStatusService : IOrderStatusService
    {
        readonly IOrderStatusReadRepository _orderStatusReadRepository;
        readonly IOrderStatusWriteRepository _orderStatusWriteRepository;

        public OrderStatusService(IOrderStatusReadRepository orderStatusReadRepository, IOrderStatusWriteRepository orderStatusWriteRepository)
        {
            _orderStatusReadRepository = orderStatusReadRepository;
            _orderStatusWriteRepository = orderStatusWriteRepository;
        }

        public async Task<OrderStatus> CreateOrderStatusAsync(string name, string? description = null)
        {
            OrderStatus orderStatus = new()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };
            await _orderStatusWriteRepository.AddAsync(orderStatus);

            return orderStatus;
        }

        public async Task<List<OrderStatus>> GetAllOrderStatusesAsync()
            => _orderStatusReadRepository.GetAll(false).ToList();
    }
}
