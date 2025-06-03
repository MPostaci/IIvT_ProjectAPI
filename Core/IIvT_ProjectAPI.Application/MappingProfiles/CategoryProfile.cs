using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs;
using IIvT_ProjectAPI.Application.DTOs.Category;
using IIvT_ProjectAPI.Application.Features.Commands.Category.UpdateCategory;
using IIvT_ProjectAPI.Domain.Entities;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, ListCategoryDto>()
                .ForMember(dest => dest.ContentType,
                           opt => opt.MapFrom(src => new EnumDto
                           {
                               Id = (int)src.ContentType,
                               Name = src.ContentType.ToString()
                           }))
                .ReverseMap()
                .ForMember(dest => dest.ContentType,
                           opt => opt.MapFrom(src => (ContentTypeEnum)src.ContentType.Id));


            CreateMap<CreateCategoryDto, Category>();


            CreateMap<UpdateCategoryCommandRequest, UpdateCategoryDto>();

            CreateMap<UpdateCategoryDto, Category>()
                .ForMember(dest => dest.ContentType, opt => opt.PreCondition((src, dest, srcMember) =>
                    Enum.IsDefined(typeof(ContentTypeEnum), src.ContentType)))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null && !(srcMember is string s && string.IsNullOrEmpty(s))));
        }
    }
}