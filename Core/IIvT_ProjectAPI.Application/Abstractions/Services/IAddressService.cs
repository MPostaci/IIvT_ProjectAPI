using IIvT_ProjectAPI.Application.DTOs.Address;
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
    }
}
