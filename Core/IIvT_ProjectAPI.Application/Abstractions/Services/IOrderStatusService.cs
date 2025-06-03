using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IOrderStatusService
    {
        /// <summary>
        /// Creates a new order status.
        /// </summary>
        /// <param name="name">The name of the order status.</param>
        /// <param name="description">An optional description of the order status.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        
        Task<OrderStatus> CreateOrderStatusAsync(string name, string? description = null);
        /// <summary>
        /// Retrieves all order statuses.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation, containing a list of order statuses.</returns>
        Task<List<OrderStatus>> GetAllOrderStatusesAsync();
    }
}
