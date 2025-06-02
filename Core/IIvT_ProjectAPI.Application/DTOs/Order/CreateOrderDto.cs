using IIvT_ProjectAPI.Domain.Entities.Identity;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IIvT_ProjectAPI.Application.DTOs.Address;

namespace IIvT_ProjectAPI.Application.DTOs.Order
{
    public class CreateOrderDto
    {
        public string? ShippingAddressId { get; set; }
        public string? BillingAddressId { get; set; }
        public CreateAddressDto? ShippingAddress { get; set; }
        public CreateAddressDto? BillingAddress { get; set; }
    }
}
