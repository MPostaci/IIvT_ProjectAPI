using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.DTOs.Address
{
    public class GetAddressDto
    {
        public Guid Id { get; set; }

        public Guid CityId { get; set; }
        public string CityName { get; set; }

        public Guid DistrictId { get; set; }
        public string DistrictName { get; set; }

        public Guid NeighborhoodId { get; set; }
        public string NeighborhoodName { get; set; }

        public string Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? Description { get; set; }

        public string FullAddress { get; set; }
    }
}
