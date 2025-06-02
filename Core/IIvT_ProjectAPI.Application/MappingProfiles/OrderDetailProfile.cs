using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<CreateOrderDetailDto, OrderDetail>();

            CreateMap<OrderDetail, ListOrderDetailDto>();
        }
    }
}
