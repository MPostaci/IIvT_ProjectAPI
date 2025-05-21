using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Basket
{
    public class ListBasketDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<BasketItemDto> Items { get; set; } = new();
        public decimal TotalPrice => Items.Sum(x => x.TotalPrice);
    }
}
