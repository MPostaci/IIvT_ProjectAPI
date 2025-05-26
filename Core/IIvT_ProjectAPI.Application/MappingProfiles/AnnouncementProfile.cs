using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using IIvT_ProjectAPI.Application.DTOs.Basket;
using IIvT_ProjectAPI.Application.Features.Commands.Announcement.CreateAnnouncement;
using IIvT_ProjectAPI.Application.Features.Commands.Announcement.UpdateAnnouncement;
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

            CreateMap<Announcement, ListAnnouncementDto>()
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.Category.ContentType));
            CreateMap<UpdateAnnouncementCommandRequest, UpdateAnnouncementDto>();
            CreateMap<UpdateAnnouncementDto, Announcement>()
                .ForMember(dest => dest.CategoryId, opt => {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.CategoryId));
                    opt.MapFrom(src => ParseGuid(src.CategoryId));
                })
                .ForMember(opt => opt.File, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null && !(srcMember is string s && string.IsNullOrEmpty(s))
                ));
        }

        private static Guid ParseGuid(string? categoryId)
        {
            return Guid.TryParse(categoryId, out var guid) ? guid : Guid.Empty;
        }
    }
}
