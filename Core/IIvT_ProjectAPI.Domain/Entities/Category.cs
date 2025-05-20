using IIvT_ProjectAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContentTypeEnum ContentType { get; set; }
        public NewsItem NewsItem { get; set; }
        public Announcement Announcement { get; set; }
    }
}
