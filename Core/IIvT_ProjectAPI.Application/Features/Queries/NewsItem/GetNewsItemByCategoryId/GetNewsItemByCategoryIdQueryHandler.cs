using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetAllNewsItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByCategoryId
{
    public class GetNewsItemByCategoryIdQueryHandler : IRequestHandler<GetNewsItemByCategoryIdQueryRequest, PagedResponse<GetNewsItemByCategoryIdQueryResponse>>
    {
        readonly INewsItemService _newsItemService;
        readonly IMapper _mapper;

        public GetNewsItemByCategoryIdQueryHandler(IMapper mapper, INewsItemService newsItemService)
        {
            _mapper = mapper;
            _newsItemService = newsItemService;
        }

        public async Task<PagedResponse<GetNewsItemByCategoryIdQueryResponse>> Handle(GetNewsItemByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _newsItemService.GetNewsItemsByCategoryIdAsync(request.CategoryId, 
                new PagedRequest {PageNumber = request.PageNumber, PageSize = request.PageSize }
                );

            return _mapper.Map<PagedResponse<GetNewsItemByCategoryIdQueryResponse>>(response);
        }
    }
}
