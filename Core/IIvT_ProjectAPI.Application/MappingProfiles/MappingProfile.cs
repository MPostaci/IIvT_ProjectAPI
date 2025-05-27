using AutoMapper;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.NewsItem;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetAllNewsItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap(typeof(PagedResponse<>), typeof(PagedResponse<>));


        }
    }
}
