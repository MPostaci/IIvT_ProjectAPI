using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Commands.Address.CreateAddress
{
    public class CreateAddressCommandRequest : IRequest<GetAddressDto>, ICommandRequest
    {
        public string CityId { get; set; }
        public string DistrictId { get; set; }
        public string NeighborhoodId { get; set; }
        public string Street { get; set; }
        public string? BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string? PostalCode { get; set; }
        public string? Description { get; set; }
    }
}
