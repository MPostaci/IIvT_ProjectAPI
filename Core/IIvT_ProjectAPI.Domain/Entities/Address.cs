using IIvT_ProjectAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class Address : SoftDeleteEntity
    {
        public Guid CityId { get; set; }
        public Guid DistrictId { get; set; }
        public Guid NeighborhoodId { get; set; }
        public string Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? Description { get; set; }
        public string FullAddress
        {
            get
            {
                var parts = new List<string?>
                {
                    Street,
                    BuildingNumber,
                    ApartmentNumber,
                    Neighborhood?.Name,
                    District?.Name,
                    City?.Name,
                    PostalCode
                };

                return string.Join(", ", parts.Where(p => !string.IsNullOrWhiteSpace(p)));
            }
        }
        public City City { get; set; }
        public District District { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
