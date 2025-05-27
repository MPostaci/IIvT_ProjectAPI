using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.NewsItem;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItem.CreateNewsItem
{
    public class CreateNewsItemCommandHandler : IRequestHandler<CreateNewsItemCommandRequest, CreateNewsItemCommandResponse>
    {
        readonly INewsItemService _newsItemService;
        readonly IMapper _mapper;

        public CreateNewsItemCommandHandler(INewsItemService newsItemService, IMapper mapper)
        {
            _newsItemService = newsItemService;
            _mapper = mapper;
        }

        public async Task<CreateNewsItemCommandResponse> Handle(CreateNewsItemCommandRequest request, CancellationToken cancellationToken)
        {
            CreateNewsItemDto dto = new();

            dto.Files = request.Files;
            var response = await _newsItemService.CreateNewsItemAsync(_mapper.Map(request, dto));

            return _mapper.Map<CreateNewsItemCommandResponse>(response);
        }
    }
}
