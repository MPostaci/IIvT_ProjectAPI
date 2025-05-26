using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace IIvT_ProjectAPI.Application.Features.Commands.Announcement.UpdateAnnouncement
{
    public class UpdateAnnouncementCommandRequest : IRequest<UpdateAnnouncementCommandResponse>, ICommandRequest
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public string? CategoryId { get; set; }
        public string? PublisherId { get; set; }
        public IFormFile? File { get; set; }
    }
}