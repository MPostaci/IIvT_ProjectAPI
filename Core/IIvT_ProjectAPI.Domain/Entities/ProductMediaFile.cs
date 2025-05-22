using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class ProductMediaFile : MediaFile
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public bool Showcase { get; set; } = false;
    }
}
