using AutoMapper;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.NewsItem;
using IIvT_ProjectAPI.Application.Features.Commands.NewsItem.CreateNewsItem;
using IIvT_ProjectAPI.Application.Features.Commands.NewsItem.UpdateNewsItem;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetAllNewsItem;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByCategoryId;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemById;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByPublisherId;
using IIvT_ProjectAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.MappingProfiles
{
    public class NewsItemProfile : Profile
    {
        public NewsItemProfile()
        {
            CreateMap<CreateNewsItemCommandRequest, CreateNewsItemDto>()
                .ForPath(dest => dest.Files, opt => opt.Ignore());

            CreateMap<UpdateNewsItemCommandRequest, UpdateNewsItemDto>();

            CreateMap<CreateNewsItemDto, NewsItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => Guid.Parse(src.CategoryId)))
                .ForMember(dest => dest.PublisherId, opt => opt.Ignore())
                .ForMember(dest => dest.Files, opt => opt.Ignore());


            CreateMap<UpdateNewsItemDto, NewsItem>();


            CreateMap<NewsItem, ListNewsItemDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CategoryDescription, opt => opt.MapFrom(src => src.Category.Description))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.Category.ContentType));

            CreateMap<ListNewsItemDto, CreateNewsItemCommandResponse>();

            CreateMap<ListNewsItemDto, UpdateNewsItemCommandResponse>();

            CreateMap<ListNewsItemDto, GetAllNewsItemQueryResponse>();
            CreateMap<ListNewsItemDto, GetNewsItemByIdQueryResponse>();
            CreateMap<ListNewsItemDto, GetNewsItemByCategoryIdQueryResponse>();
            CreateMap<ListNewsItemDto, GetNewsItemByPublisherIdQueryResponse>();

            CreateMap<NewsItemMediaFile, NewsItemMediaFileDto>();
        }
    }
}