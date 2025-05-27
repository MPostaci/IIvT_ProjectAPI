using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.NewsItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItem.UpdateNewsItem
{
    public class UpdateNewsItemCommandHandler : IRequestHandler<UpdateNewsItemCommandRequest, UpdateNewsItemCommandResponse>
    {
        readonly INewsItemService _newsItemService;
        readonly IMapper _mapper;

        public UpdateNewsItemCommandHandler(INewsItemService newsItemService, IMapper mapper)
        {
            _newsItemService = newsItemService;
            _mapper = mapper;
        }

        public async Task<UpdateNewsItemCommandResponse> Handle(UpdateNewsItemCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _newsItemService.UpdateNewsItemAsync(_mapper.Map<UpdateNewsItemDto>(request));

            return _mapper.Map<UpdateNewsItemCommandResponse>(response);
        }
    }
}
