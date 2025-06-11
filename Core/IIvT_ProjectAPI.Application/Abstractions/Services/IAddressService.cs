using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IAddressService
    {
        Task<List<CityLookupDto>> GetCitiesAsync(CancellationToken ct = default);
        Task<List<DistrictLookupDto>> GetDistrictsByCityIdAsync(string cityId, CancellationToken ct = default);
        Task<List<NeighborhoodLookupDto>> GetNeighborhoodsByDistrictIdAsync(string districtId, CancellationToken ct = default);
        Task<PagedResponse<GetAddressDto>> GetAddresses(PagedRequest request);
        Task<ListAddressDto> GetAddressByIdAsync(string addressId);
        Task<GetAddressDto> AddAddressAsync(CreateAddressDto dto);
        Task<GetAddressDto> UpsertAsync(string? addressId, CreateAddressDto? dto);
        Task<GetAddressDto> UpdateAddressAsync(UpdateAddressDto dto);
        Task<bool> DeleteAddressAsync(string addressId);
    }
}
