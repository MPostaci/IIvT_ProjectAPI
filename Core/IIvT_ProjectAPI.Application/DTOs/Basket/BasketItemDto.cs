using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Basket
{
    public class BasketItemDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
