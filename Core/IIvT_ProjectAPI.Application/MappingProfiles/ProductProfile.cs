using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Product;
using IIvT_ProjectAPI.Application.Features.Commands.Product.CreateProduct;
using IIvT_ProjectAPI.Application.Features.Commands.Product.UpdateProduct;
using IIvT_ProjectAPI.Domain.Entities;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ListProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<CreateProductCommandRequest, CreateProductDto>();
            CreateMap<UpdateProductCommandRequest, UpdateProductDto>();
        }
    }
}
