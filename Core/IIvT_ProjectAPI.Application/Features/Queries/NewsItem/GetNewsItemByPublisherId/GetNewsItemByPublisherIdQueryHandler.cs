using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemByPublisherId
{
    public class GetNewsItemByPublisherIdQueryHandler : IRequestHandler<GetNewsItemByPublisherIdQueryRequest, PagedResponse<GetNewsItemByPublisherIdQueryResponse>>
    {
        readonly INewsItemService _newsItemService;
        readonly IMapper _mapper;

        public GetNewsItemByPublisherIdQueryHandler(INewsItemService newsItemService, IMapper mapper)
        {
            _newsItemService = newsItemService;
            _mapper = mapper;
        }

        public async Task<PagedResponse<GetNewsItemByPublisherIdQueryResponse>> Handle(GetNewsItemByPublisherIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _newsItemService.GetNewsItemsByPublisherIdAsync(request.Id,
                new PagedRequest { PageNumber = request.PageNumber, PageSize = request.PageSize });

            return _mapper.Map<PagedResponse<GetNewsItemByPublisherIdQueryResponse>>(response);
        }
    }
}
