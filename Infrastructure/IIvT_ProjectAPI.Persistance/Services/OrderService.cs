using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.DTOs.Order;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using IIvT_ProjectAPI.Application.Exceptions;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Consts;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class OrderService : IOrderService
    {
        readonly IMapper _mapper;
        readonly IOrderReadRepository _orderReadRepository;
        readonly IOrderWriteRepository _orderWriteRepository;
        readonly IAddressService _addressService;
        readonly UserManager<AppUser> _userManager;
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly IBasketService _basketService;
        readonly IOrderDetailService _orderDetailService;

        public OrderService(IOrderWriteRepository orderWriteRepository, IMapper mapper, IOrderReadRepository orderReadRepository, IAddressService addressService, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor, IBasketService basketService, IOrderDetailService orderDetailService)
        {
            _mapper = mapper;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _addressService = addressService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _basketService = basketService;
            _orderDetailService = orderDetailService;
        }

        public async Task<string> ContextUser()
        {
            var username = _httpContextAccessor?.HttpContext?.User.Identity?.Name
                ?? throw new NotFoundUserException();

            var user = await _userManager.FindByNameAsync(username)
                ?? throw new NotFoundUserException($"User with username {username} not found.");

            return user.Id;
        }

        public async Task<PagedResponse<ListOrderWithDetailsDto>> GetAllOrdersWithDetails(PagedRequest pagedRequest)
        {
            var query = _orderReadRepository.GetAll(false);

            return await query.ToPagedListAsync<Order, ListOrderWithDetailsDto>(_mapper, pagedRequest);
        }

        public async Task<ListOrderDto> CreateOrderAsync(CreateOrderDto dto)
        {
            var shippingAddr = await _addressService
                .UpsertAsync(
                   addressId: dto.ShippingAddressId,
                   dto: dto.ShippingAddress);

            var billingAddr = await _addressService
                .UpsertAsync(
                   addressId: dto.BillingAddressId,
                   dto: dto.BillingAddress);


            var orderCode = (new Random().NextDouble() * 10000).ToString();
            orderCode = orderCode.Substring(orderCode.IndexOf(",") + 1, orderCode.Length - orderCode.IndexOf(",") - 1);


            var basket = await _basketService.Checkout();

            Guid orderId = Guid.NewGuid();

            var order = new Order
            {
                Id = orderId,
                ShippingAddressId = shippingAddr.Id,
                BillingAddressId = billingAddr.Id,
                OrderCode = orderCode,
                TotalAmount = basket.TotalPrice,
                OrderStatusId = OrderStatusConstants.Pending
            };

            string userId = await ContextUser();
            order.UserId = userId;

            await _orderWriteRepository.AddAsync(order);

            List<CreateOrderDetailDto> list = new();

            foreach (var basketItem in basket.Items)
            {
                list.Add(new CreateOrderDetailDto()
                {
                    OrderId = orderId,
                    Price = basketItem.Price,
                    ProductId = basketItem.ProductId,
                    Quantity = basketItem.Quantity,
                });
            }

            var orderDetails = await _orderDetailService.CreateOrderDetail(list);

            //order.OrderDetails = orderDetails;

            //_orderWriteRepository.Update(order);

            var result = _mapper.Map<ListOrderDto>(order);
            return result;
        }

        // Helper to parse or return null
        private Guid? TryParseGuid(string? id)
          => Guid.TryParse(id, out var g) ? g : (Guid?)null;

        public async Task<ListOrderWithDetailsDto> GetOrderWithDetailById(string id)
        {
            var order = await _orderReadRepository.GetAll(false)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.ShippingAddress)
                    .ThenInclude(a => a.City)
                .Include(o => o.ShippingAddress)
                    .ThenInclude(a => a.District)
                .Include(o => o.ShippingAddress)
                    .ThenInclude(a => a.Neighborhood)
                .Include(o => o.BillingAddress)
                    .ThenInclude(a => a.City)
                .Include(o => o.BillingAddress)
                    .ThenInclude(a => a.District)
                .Include(o => o.BillingAddress)
                    .ThenInclude(a => a.Neighborhood)
                .Include(o => o.OrderStatus)
                .FirstOrDefaultAsync(o => o.Id == Guid.Parse(id));


            return _mapper.Map<ListOrderWithDetailsDto>(order);

        }

        public async Task<PagedResponse<ListOrderWithDetailsDto>> GetOrdersWithDetailByUserId(PagedRequest pagedRequest)
        {
            string userId = await ContextUser();

            var query = _orderReadRepository.GetWhere(x => x.UserId == userId);
            return await query.ToPagedListAsync<Order, ListOrderWithDetailsDto>(_mapper, pagedRequest);
        }

        public async Task<PagedResponse<ListOrderWithDetailsDto>> GetOrdersWithDetailByUserId(string userId, PagedRequest pagedRequest)
            => await _orderReadRepository.GetWhere(x => x.UserId == userId).ToPagedListAsync<Order, ListOrderWithDetailsDto>(_mapper, pagedRequest);

        public async Task<ListOrderWithDetailsDto> GetOrderByOrderCode(string orderCode)
        {
            var order = await _orderReadRepository.GetAll(false)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Product)
                .Include(o => o.ShippingAddress)
                    .ThenInclude(a => a.City)
                .Include(o => o.ShippingAddress)
                    .ThenInclude(a => a.District)
                .Include(o => o.ShippingAddress)
                    .ThenInclude(a => a.Neighborhood)
                .Include(o => o.BillingAddress)
                    .ThenInclude(a => a.City)
                .Include(o => o.BillingAddress)
                    .ThenInclude(a => a.District)
                .Include(o => o.BillingAddress)
                    .ThenInclude(a => a.Neighborhood)
                .Include(o => o.OrderStatus)
                .FirstOrDefaultAsync(o => o.OrderCode == orderCode);


            return _mapper.Map<ListOrderWithDetailsDto>(order);
        }

        public async Task<PagedResponse<ListOrderWithDetailsDto>> GetOrderByOrderStatus(string orderStatusId, PagedRequest pagedRequest)
            => await _orderReadRepository.GetWhere(x => x.OrderStatusId == TryParseGuid(orderStatusId)).ToPagedListAsync<Order, ListOrderWithDetailsDto>(_mapper, pagedRequest);
    }
}
