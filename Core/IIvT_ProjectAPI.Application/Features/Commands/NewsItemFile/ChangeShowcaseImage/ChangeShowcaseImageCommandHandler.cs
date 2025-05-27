using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.NewsItemFile.ChangeShowcaseImage
{
    public class ChangeShowcaseImageCommandHandler : IRequestHandler<ChangeShowcaseImageCommandRequest, ChangeShowcaseImageCommandResponse>
    {
        readonly INewsItemService _newsItemService;

        public ChangeShowcaseImageCommandHandler(INewsItemService newsItemService)
        {
            _newsItemService = newsItemService;
        }

        public async Task<ChangeShowcaseImageCommandResponse> Handle(ChangeShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _newsItemService.ChangeShowcaseFile(request.NewsItemId, request.FileId);

            return new()
            {
                IsSuccess = result,
                Message = result ? "Showcase image changed successfully." : "Failed to change showcase image. Please try again later."
            };
        }
    }
}
