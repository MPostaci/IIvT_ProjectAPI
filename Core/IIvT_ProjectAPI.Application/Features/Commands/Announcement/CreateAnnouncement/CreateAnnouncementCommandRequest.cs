using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IIvT_ProjectAPI.Application.Features.Commands.Announcement.CreateAnnouncement
{
    public class CreateAnnouncementCommandRequest : IRequest<CreateAnnouncementCommandResponse>, ICommandRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CategoryId { get; set; }
        public IFormFileCollection File { get; set; }
    }
}