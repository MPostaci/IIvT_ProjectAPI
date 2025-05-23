using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Announcement
{
    public class ListAnnouncementDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public ContentTypeEnum ContentType { get; set; }
        public string PublisherFullName { get; set; }
        public string PublisherId { get; set; }
        public AnnouncementMediaFile File { get; set; }

    }
}
