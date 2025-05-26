using IIvT_ProjectAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Announcement
{
    public class UpdateAnnouncementDto
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
