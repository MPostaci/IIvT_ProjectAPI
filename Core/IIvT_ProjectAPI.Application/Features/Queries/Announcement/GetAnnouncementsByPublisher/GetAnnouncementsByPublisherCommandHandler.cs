using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAnnouncementsByPublisher
{
    public class GetAnnouncementsByPublisherCommandHandler : IRequestHandler<GetAnnouncementsByPublisherCommandRequest, PagedResponse<ListAnnouncementDto>>
    {
        readonly IAnnouncementService _announcementService;
        public GetAnnouncementsByPublisherCommandHandler(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        public async Task<PagedResponse<ListAnnouncementDto>> Handle(GetAnnouncementsByPublisherCommandRequest request, CancellationToken cancellationToken)
        {
            PagedRequest pagedRequest = new()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };
            return await _announcementService.GetAnnouncementsByPublisherAsync(pagedRequest, request.PublisherId);
        }
    }
}
