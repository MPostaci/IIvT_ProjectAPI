using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Product;
using IIvT_ProjectAPI.Application.Features.Commands.Product.CreateProduct;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ListProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<CreateProductCommandRequest, CreateProductDto>();


            //// Product → ListProductDto
            //CreateMap<Product, ListProductDto>()
            //    // MediaFile → MediaFileDto profiline yönlendir
            //    .ForMember(dest => dest.Images,
            //               opt => opt.MapFrom(src => src.Images))
            //    // Eğer ListProductDto’da BasketItems yoksa aşağıyı ekle:
            //    .ForAllOtherMembers(opt => opt.Ignore());

            //// MediaFile → MediaFileDto
            //CreateMap<MediaFile, MediaFileDto>();
        }
    }
}
