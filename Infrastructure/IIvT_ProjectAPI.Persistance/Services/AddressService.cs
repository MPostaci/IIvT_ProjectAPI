using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class AddressService : IAddressService
    {
        readonly ICityReadRepository _cityReadRepository;
        readonly IDistrictReadRepository _districtReadRepository;
        readonly INeighborhoodReadRepository _neighborhoodReadRepository;

        public AddressService(ICityReadRepository cityReadRepository, IDistrictReadRepository districtReadRepository, INeighborhoodReadRepository neighborhoodReadRepository)
        {
            _cityReadRepository = cityReadRepository;
            _districtReadRepository = districtReadRepository;
            _neighborhoodReadRepository = neighborhoodReadRepository;
        }

        public Task<List<CityLookupDto>> GetCitiesAsync(CancellationToken ct = default)
            => _cityReadRepository.Table
            .AsNoTracking()
            .OrderBy(c => c.Name)
            .Select(c => new CityLookupDto(c.Id, c.Name))
            .ToListAsync(ct);

        public Task<List<DistrictLookupDto>> GetDistrictsByCityIdAsync(string cityId, CancellationToken ct = default)
            => _districtReadRepository.Table
            .AsNoTracking()
            .Where(d => d.CityId == Guid.Parse(cityId))
            .OrderBy(d => d.Name)
            .Select(d => new DistrictLookupDto(d.Id, d.Name))
            .ToListAsync(ct);

        public Task<List<NeighborhoodLookupDto>> GetNeighborhoodsByDistrictIdAsync(string districtId, CancellationToken ct = default)
            => _neighborhoodReadRepository.Table
            .AsNoTracking()
            .Where(n => n.DistrictId == Guid.Parse(districtId))
            .OrderBy(n => n.Name)
            .Select(n => new NeighborhoodLookupDto(n.Id, n.Name))
            .ToListAsync(ct);
    }
}
