using AutoMapper;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AppRole, IDictionary<string, string>>()
                .ConvertUsing(src => new Dictionary<string, string>
                {
                    { "Id", src.Id },
                    { "Name", src.Name },
                    { "NormalizedName", src.NormalizedName }
                });
        }
    }
}
