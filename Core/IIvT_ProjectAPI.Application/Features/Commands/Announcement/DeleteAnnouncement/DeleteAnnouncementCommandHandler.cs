using IIvT_ProjectAPI.Application.Abstractions.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Announcement.DeleteAnnouncement
{
    public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommandRequest, DeleteAnnouncementCommandResponse>
    {
        readonly IAnnouncementService _announcementService;

        public DeleteAnnouncementCommandHandler(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public async Task<DeleteAnnouncementCommandResponse> Handle(DeleteAnnouncementCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _announcementService.DeleteAnnouncement(request.Id);

            return new()
            {
                IsSuccess = result,
                Message = result ? "Announcement deleted successfully." : "Failed to delete announcement."
            };
        }
    }
}
