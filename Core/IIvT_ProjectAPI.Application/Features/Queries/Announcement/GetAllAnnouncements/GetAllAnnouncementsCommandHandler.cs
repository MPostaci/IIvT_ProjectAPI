using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Announcement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Announcement.GetAllAnnouncements
{
    public class GetAllAnnouncementsCommandHandler : IRequestHandler<GetAllAnnouncementsCommandRequest, PagedResponse<ListAnnouncementDto>>
    {
        readonly IAnnouncementService _announcementService;

        public GetAllAnnouncementsCommandHandler(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<PagedResponse<ListAnnouncementDto>> Handle(GetAllAnnouncementsCommandRequest request, CancellationToken cancellationToken)
        {
            return await _announcementService.GetAllAnnouncementsAsync(request);
        }
    }
}
