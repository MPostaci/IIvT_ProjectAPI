using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class NewsItemMediaFile : MediaFile
    {
        public Guid NewsItemId { get; set; }
        public NewsItem NewsItem { get; set; }
        public bool Showcase { get; set; } = false;
    }
}
