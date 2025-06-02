using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        readonly IMapper _mapper;
        readonly IOrderDetailReadRepository _orderDetailReadRepository;
        readonly IOrderDetailWriteRepository _orderDetailWriteRepository;

        public OrderDetailService(IMapper mapper, IOrderDetailReadRepository orderDetailReadRepository, IOrderDetailWriteRepository orderDetailWriteRepository)
        {
            _mapper = mapper;
            _orderDetailReadRepository = orderDetailReadRepository;
            _orderDetailWriteRepository = orderDetailWriteRepository;
        }

        public async Task<List<OrderDetail>> CreateOrderDetail(List<CreateOrderDetailDto> dto)
        {
            var orderDetails = _mapper.Map<List<OrderDetail>>(dto);
            await _orderDetailWriteRepository.AddRangeAsync(orderDetails);
            return orderDetails;
        }
    }
}
