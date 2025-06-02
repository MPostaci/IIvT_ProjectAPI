using IIvT_ProjectAPI.Application.DTOs.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.OrderDetail
{
    public class ListOrderWithDetailsDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ShippingAddressId { get; set; }
        public string BillingAddressId { get; set; }
        public string OrderCode { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public string OrderStatusDescription { get; set; }
        public GetAddressDto ShippingAddress { get; set; }
        public GetAddressDto BillingAddress { get; set; }
        public IEnumerable<ListOrderDetailDto> OrderDetails { get; set; }
    }
}
