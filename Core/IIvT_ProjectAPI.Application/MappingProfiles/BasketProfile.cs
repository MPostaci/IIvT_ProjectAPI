using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Basket;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, ListBasketDto>()
                .ConvertUsing(src => new ListBasketDto
                {
                    Id = src.Id,
                    UserId = src.UserId,
                    Items = src.BasketItems.Select(x => new BasketItemDto
                    {
                        ProductId = x.ProductId,
                        Name = x.Product.Name,
                        Stock = x.Product.Stock,
                        Price = x.Price,
                        Quantity = x.Quantity,
                    }).ToList()
                });
        }
    }
}
