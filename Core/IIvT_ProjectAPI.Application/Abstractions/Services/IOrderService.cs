using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Order;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IOrderService
    {
        Task<PagedResponse<ListOrderWithDetailsDto>> GetAllOrdersWithDetails(PagedRequest pagedRequest);
        Task<ListOrderWithDetailsDto> GetOrderWithDetailById(string id);
        Task<PagedResponse<ListOrderWithDetailsDto>> GetOrdersWithDetailByUserId(PagedRequest pagedRequest);
        Task<PagedResponse<ListOrderWithDetailsDto>> GetOrdersWithDetailByUserId(string userId, PagedRequest pagedRequest);
        Task<ListOrderWithDetailsDto> GetOrderByOrderCode(string orderCode);
        Task<PagedResponse<ListOrderWithDetailsDto>> GetOrderByOrderStatus(string orderStatusId, PagedRequest pagedRequest);

        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="userId">The ID of the user placing the order.</param>
        /// <param name="shippingAddress">The shipping address for the order.</param>
        /// <param name="billingAddress">The billing address for the order.</param>
        /// <returns>A task that represents the asynchronous operation, containing the created order details.</returns>
        Task<ListOrderDto> CreateOrderAsync(CreateOrderDto createOrderDto);

    }
}
