using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Address
{
    public class UpdateAddressDto
    {
        public string Id { get; set; }
        public string? CityId { get; set; }
        public string? DistrictId { get; set; }
        public string? NeighborhoodId { get; set; }
        public string? Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? Description { get; set; }
    }
}
