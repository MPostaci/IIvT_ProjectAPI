﻿using IIvT_ProjectAPI.Domain.Entities.Common;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class Announcement : SoftDeleteEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Guid CategoryId { get; set; }
        public string PublisherId { get; set; }
        public Category Category { get; set; }
        public AppUser Publisher { get; set; }
        public AnnouncementMediaFile File { get; set; }
    }
}
