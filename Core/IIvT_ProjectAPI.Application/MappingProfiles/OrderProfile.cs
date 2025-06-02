using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Order;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using IIvT_ProjectAPI.Application.Features.Commands.Order.CreateOrder;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrderCommandRequest, CreateOrderDto>();

            CreateMap<CreateOrderDto, Order>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Order, ListOrderDto>()
                .ForMember(dest => dest.ShippingAddressId, opt => opt.MapFrom(src => src.ShippingAddressId.ToString()))
                .ForMember(dest => dest.ShippingAddressId, opt => opt.MapFrom(src => src.ShippingAddressId.ToString()))
                .ForMember(dest => dest.OrderStatusId, opt => opt.MapFrom(src => src.OrderStatusId.ToString()))
                .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));

            CreateMap<Order, ListOrderWithDetailsDto>()
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress))
                .ForMember(dest => dest.BillingAddress, opt => opt.MapFrom(src => src.BillingAddress));
        }

        private Guid ParseGuid(string id)
        {
            if (!Guid.TryParse(id, out Guid parsedId))
                throw new ArgumentException("Invalid id format.", nameof(id));
            return parsedId;
        }
    }
}
