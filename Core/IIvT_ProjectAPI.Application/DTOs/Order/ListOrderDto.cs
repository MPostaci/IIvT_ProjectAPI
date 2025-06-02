using IIvT_ProjectAPI.Application.DTOs.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Order
{
    public class ListOrderDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ShippingAddressId { get; set; }
        public string BillingAddressId { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatusId { get; set; }
        public List<ListOrderDetailDto> OrderDetails { get; set; }
    }
}
