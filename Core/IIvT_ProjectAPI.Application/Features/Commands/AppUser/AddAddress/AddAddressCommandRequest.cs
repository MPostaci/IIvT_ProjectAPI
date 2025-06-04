using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Commands.AppUser.AddAddress
{
    public class AddAddressCommandRequest : IRequest<GetAddressDto>, ICommandRequest
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