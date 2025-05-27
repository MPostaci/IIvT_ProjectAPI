using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.NewsItem.GetNewsItemById
{
    public class GetNewsItemByIdQueryHandler : IRequestHandler<GetNewsItemByIdQueryRequest, GetNewsItemByIdQueryResponse>
    {
        readonly IMapper _mapper;
        readonly INewsItemService _newsItemService;

        public GetNewsItemByIdQueryHandler(IMapper mapper, INewsItemService newsItemService)
        {
            _mapper = mapper;
            _newsItemService = newsItemService;
        }

        public async Task<GetNewsItemByIdQueryResponse> Handle(GetNewsItemByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _newsItemService.GetNewsItemByIdAsync(request.Id);

            return _mapper.Map<GetNewsItemByIdQueryResponse>(response);
        }
    }
}
