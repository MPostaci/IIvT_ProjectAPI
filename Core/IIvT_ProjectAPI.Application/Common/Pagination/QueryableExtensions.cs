using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Common.Pagination
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResponse<TDestination>> ToPagedListAsync<TSource, TDestination>(
            this IQueryable<TSource> source,
            IMapper mapper,
            PagedRequest request)
        {
            var count = await source.CountAsync();
            var items = await source
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ProjectTo<TDestination>(mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResponse<TDestination>(
                items,
                count,
                request.PageNumber,
                request.PageSize
                );
        }
    }
}
