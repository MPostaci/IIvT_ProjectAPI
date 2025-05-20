using IIvT_ProjectAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class BasketItem : BaseEntity
    {
        public Guid? BasketId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
        public Basket? Basket { get; set; }
        public Product Product { get; set; }
    }
}
