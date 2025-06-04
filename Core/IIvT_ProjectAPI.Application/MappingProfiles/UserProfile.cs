using AutoMapper;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.DTOs.User;
using IIvT_ProjectAPI.Application.Features.Commands.AppUser.AddAddress;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, ListUserDto>();
            CreateMap<AddAddressCommandRequest, CreateAddressDto>();
        }
    }
}
