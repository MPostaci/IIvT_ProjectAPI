using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using IIvT_ProjectAPI.Application.DTOs.Event;
using IIvT_ProjectAPI.Application.Features.Commands.Event.CreateEvent;
using IIvT_ProjectAPI.Application.Features.Commands.Event.UpdateEvent;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<CreateEventCommandRequest, CreateEventDto>();
            CreateMap<CreateEventDto, Event>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.AddressId, opt => opt.Ignore()); // AddressId will be set after address creation

            CreateMap<Event, ListEventDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.PublisherFullName, opt => opt.MapFrom(src => src.Publisher.FullName))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

            CreateMap<EventMediaFile, EventMediaFileDto>();

            CreateMap<UpdateEventDto, Event>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.StartDate, opt =>
                {
                    opt.PreCondition(src => src.StartDate != default);
                    opt.MapFrom(src => src.StartDate);
                })
                .ForMember(dest => dest.EndDate, opt =>
                {
                    opt.PreCondition(src => src.EndDate != default);
                    opt.MapFrom(src => src.EndDate);
                })
                .ForMember(dest => dest.AddressId, opt => opt.Ignore())
                .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
                .ForMember(dest => dest.PublisherId, opt => opt.Ignore())
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null && !(srcMember is string s && string.IsNullOrEmpty(s))));

            CreateMap<UpdateEventCommandRequest, UpdateEventDto>();
        }
    }
}
