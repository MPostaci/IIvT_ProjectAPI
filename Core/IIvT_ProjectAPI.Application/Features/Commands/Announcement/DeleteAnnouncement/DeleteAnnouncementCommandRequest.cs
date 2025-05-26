using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.Announcement.DeleteAnnouncement
{
    public class DeleteAnnouncementCommandRequest : IRequest<DeleteAnnouncementCommandResponse>, ICommandRequest
    {
        public string Id { get; set; }
    }
}