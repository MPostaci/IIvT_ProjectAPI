using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItemFile.RemoveNewsItemFile
{
    public class RemoveNewsItemFileCommandHandler : IRequestHandler<RemoveNewsItemFileCommandRequest, RemoveNewsItemFileCommandResponse>
    {
        readonly INewsItemService _newsItemService;

        public RemoveNewsItemFileCommandHandler(INewsItemService newsItemService)
        {
            _newsItemService = newsItemService;
        }

        public async Task<RemoveNewsItemFileCommandResponse> Handle(RemoveNewsItemFileCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _newsItemService.RemoveFileAsync(request.NewsItemId, request.FileId);

            return new()
            {
                IsSuccess = result,
                Message = result ? "File removed successfully." : "Failed to remove file. Please try again later."
            };
        }
    }
}
