using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAnnouncementsByCategory
{
    public class GetAnnouncementByCategoryCommandHandler : IRequestHandler<GetAnnouncementByCategoryCommandRequest, PagedResponse<ListAnnouncementDto>>
    {
        readonly IAnnouncementService _announcementService;
        public GetAnnouncementByCategoryCommandHandler(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }
        public async Task<PagedResponse<ListAnnouncementDto>> Handle(GetAnnouncementByCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            PagedRequest pagedRequest = new()
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
            };
            return await _announcementService.GetAnnouncementsByCategoryAsync(pagedRequest, request.CategoryId);
        }
    }
}
