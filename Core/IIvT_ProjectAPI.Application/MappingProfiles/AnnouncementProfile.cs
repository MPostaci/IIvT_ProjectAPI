using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using IIvT_ProjectAPI.Application.DTOs.Basket;
using IIvT_ProjectAPI.Application.Features.Commands.Announcement.CreateAnnouncement;
using IIvT_ProjectAPI.Domain.Entities;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class AnnouncementProfile : Profile
    {
        public AnnouncementProfile()
        {
            CreateMap<CreateAnnouncementCommandRequest, CreateAnnouncementDto>()
                .ConvertUsing(src => new CreateAnnouncementDto
                {
                    Title = src.Title,
                    File = src.File,
                    Description = src.Description,
                    Content = src.Content,
                    CategoryId = src.CategoryId,
                });

            //CreateMap<CreateAnnouncementDto, Announcement>();
            CreateMap<Announcement, ListAnnouncementDto>()
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.Category.ContentType));
                //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                //.ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Category.Description))
                //.ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.Category.ContentType))
                //.ForMember(dest => dest.PublisherFullName, opt => opt.MapFrom(src => src.Publisher.FullName));


            //CreateMap<Basket, ListBasketDto>()
            //    .ConvertUsing(src => new ListBasketDto
            //    {
            //        Id = src.Id,
            //        UserId = src.UserId,
            //        Items = src.BasketItems.Select(x => new BasketItemDto
            //        {
            //            ProductId = x.ProductId,
            //            Name = x.Product.Name,
            //            Stock = x.Product.Stock,
            //            Price = x.Price,
            //            Quantity = x.Quantity,
            //        }).ToList()
            //    });
        }
    }
}
