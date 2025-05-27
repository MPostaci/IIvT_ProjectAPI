using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItem.DeleteNewsItem
{
    public class DeleteNewsItemCommandHandler : IRequestHandler<DeleteNewsItemCommandRequest, DeleteNewsItemCommandResponse>
    {
        readonly INewsItemService _newsItemService;

        public DeleteNewsItemCommandHandler(INewsItemService newsItemService)
        {
            _newsItemService = newsItemService;
        }

        public async Task<DeleteNewsItemCommandResponse> Handle(DeleteNewsItemCommandRequest request, CancellationToken cancellationToken)
        {
            await _newsItemService.DeleteNewsItemAsync(request.Id);

            return new DeleteNewsItemCommandResponse
            {
                IsSuccess = true,
                Message = "News item deleted successfully."
            };
        }
    }
}
