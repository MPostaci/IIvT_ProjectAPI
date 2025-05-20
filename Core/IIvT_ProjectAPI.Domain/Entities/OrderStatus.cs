using IIvT_ProjectAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class OrderStatus : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
