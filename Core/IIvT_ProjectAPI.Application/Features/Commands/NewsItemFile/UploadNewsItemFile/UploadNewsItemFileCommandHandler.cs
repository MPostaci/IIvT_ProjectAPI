using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItemFile.UploadNewsItemFile
{
    public class UploadNewsItemFileCommandHandler : IRequestHandler<UploadNewsItemFileCommandRequest, UploadNewsItemFileCommandResponse>
    {
        readonly INewsItemService _newsItemService;

        public UploadNewsItemFileCommandHandler(INewsItemService newsItemService)
        {
            _newsItemService = newsItemService;
        }

        public async Task<UploadNewsItemFileCommandResponse> Handle(UploadNewsItemFileCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _newsItemService.UploadFilesAsync(request.NewsItemId, request.File);

            return new()
            {
                IsSuccess = result,
                Message = result ? "Files uploaded successfully." : "Failed to upload files. Please try again later."
            };
        }
    }
}
