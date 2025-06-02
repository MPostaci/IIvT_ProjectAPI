using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.Features.Commands.Address.CreateAddress;
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


            //CreateMap<Address, GetAddressDto>()
            //    .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.City.Id))
            //    .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.District.Id))
            //    .ForMember(dest => dest.NeighborhoodId, opt => opt.MapFrom(src => src.Neighborhood.Id))
            //    .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => src.FullAddress))
            //    .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name))
            //    .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
            //    .ForMember(dest => dest.NeighborhoodName, opt => opt.MapFrom(src => src.Neighborhood.Name));


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
        }

        private static Guid ParseGuid(string? id)
        {
            return Guid.TryParse(id, out var guid) ? guid : Guid.Empty;
        }
    }
}
