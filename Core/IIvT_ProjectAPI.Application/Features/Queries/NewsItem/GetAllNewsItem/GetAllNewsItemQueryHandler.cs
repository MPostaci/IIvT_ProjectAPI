using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetAllNewsItem
{
    public class GetAllNewsItemQueryHandler : IRequestHandler<GetAllNewsItemQueryRequest, PagedResponse<GetAllNewsItemQueryResponse>>
    {
        readonly INewsItemService _newsItemService;
        readonly IMapper _mapper;

        public GetAllNewsItemQueryHandler(INewsItemService newsItemService, IMapper mapper)
        {
            _newsItemService = newsItemService;
            _mapper = mapper;
        }

        public async Task<PagedResponse<GetAllNewsItemQueryResponse>> Handle(GetAllNewsItemQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _newsItemService.GetAllNewsItemsAsync(request);

            return _mapper.Map<PagedResponse<GetAllNewsItemQueryResponse>>(response);
        }
    }
}
