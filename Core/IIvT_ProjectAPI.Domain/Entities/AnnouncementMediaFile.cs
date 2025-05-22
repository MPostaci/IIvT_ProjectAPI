using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class AnnouncementMediaFile : MediaFile
    {
        public Guid AnnouncementId { get; set; }
        public Announcement Announcement { get; set; }
    }
}
