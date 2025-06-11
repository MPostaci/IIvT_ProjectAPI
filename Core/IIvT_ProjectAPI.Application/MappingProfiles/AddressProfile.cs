using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.Features.Commands.Address.CreateAddress;
using IIvT_ProjectAPI.Application.Features.Commands.Address.UpdateAddress;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDto, Address>()
                .ForMember(dest => dest.CityId, opt => opt.Ignore())
                .ForMember(dest => dest.DistrictId, opt => opt.Ignore())
                .ForMember(dest => dest.NeighborhoodId, opt => opt.Ignore())
                .ForMember(dest => dest.City, opt => opt.Ignore())
                .ForMember(dest => dest.District, opt => opt.Ignore())
                .ForMember(dest => dest.Neighborhood, opt => opt.Ignore());

            CreateMap<Address, GetAddressDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.NeighborhoodName, opt => opt.MapFrom(src => src.Neighborhood.Name))
                .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => src.FullAddress));

            CreateMap<Address, ListAddressDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
                .ForMember(dest => dest.NeighborhoodName, opt => opt.MapFrom(src => src.Neighborhood.Name))
                .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => src.FullAddress));

            CreateMap<CreateAddressCommandRequest, CreateAddressDto>();

            CreateMap<UpdateAddressCommandRequest, UpdateAddressDto>();

            CreateMap<UpdateAddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CityId, opt =>
                {
                    opt.PreCondition(x => x.CityId != null);
                    opt.MapFrom(src => TryParseGuid(src.CityId));
                })
                .ForMember(dest => dest.DistrictId, opt =>
                {
                    opt.PreCondition(x => x.DistrictId != null);
                    opt.MapFrom(src => TryParseGuid(src.DistrictId));
                })
                .ForMember(dest => dest.NeighborhoodId, opt =>
                {
                    opt.PreCondition(x => x.NeighborhoodId != null);
                    opt.MapFrom(src => TryParseGuid(src.NeighborhoodId));
                })
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null && !(srcMember is string s && string.IsNullOrEmpty(s))));
        }

        private static Guid TryParseGuid(string? id)
        {
            return Guid.TryParse(id, out var guid) ? guid : Guid.Empty;
        }
    }
}
