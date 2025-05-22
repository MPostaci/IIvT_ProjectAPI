using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class EventMediaFile : MediaFile
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; }
    }
}
