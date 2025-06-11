using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class AddressService : IAddressService
    {
        readonly IMapper _mapper;
        readonly ICityReadRepository _cityReadRepository;
        readonly IDistrictReadRepository _districtReadRepository;
        readonly INeighborhoodReadRepository _neighborhoodReadRepository;
        readonly IAddressReadRepository _addressReadRepository;
        readonly IAddressWriteRepository _addressWriteRepository;

        public AddressService(ICityReadRepository cityReadRepository, IDistrictReadRepository districtReadRepository, INeighborhoodReadRepository neighborhoodReadRepository, IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository, IMapper mapper)
        {
            _cityReadRepository = cityReadRepository;
            _districtReadRepository = districtReadRepository;
            _neighborhoodReadRepository = neighborhoodReadRepository;
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
            _mapper = mapper;
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

        public async Task<PagedResponse<GetAddressDto>> GetAddresses(PagedRequest request)
        {
            var query = _addressReadRepository.GetAll();

            return await query.ToPagedListAsync<Address, GetAddressDto>(_mapper, request);
        }

        public async Task<ListAddressDto> GetAddressByIdAsync(string addressId)
            => _mapper.Map<ListAddressDto>(await _addressReadRepository.GetByIdAsync(addressId));


        public async Task<GetAddressDto> AddAddressAsync(CreateAddressDto dto)
        {
            var city = await _cityReadRepository.GetByIdAsync(dto.CityId)
                ?? throw new ArgumentException($"City with ID {dto.CityId} does not exist.");

            var district = await _districtReadRepository.GetByIdAsync(dto.DistrictId)
                ?? throw new ArgumentException($"District with ID {dto.DistrictId} does not exist.");

            if (district.CityId != city.Id)
                throw new ArgumentException($"District {district.Name} does not belong to city {city.Name}.");

            var neighborhood = await _neighborhoodReadRepository.GetByIdAsync(dto.NeighborhoodId)
                ?? throw new ArgumentException($"Neighborhood with ID {dto.NeighborhoodId} does not exist.");

            if (neighborhood.DistrictId != district.Id)
                throw new ArgumentException($"Neighborhood {neighborhood.Name} does not belong to district {district.Name}.");

            var address = _mapper.Map<Address>(dto);

            address.CityId = city.Id;
            address.DistrictId = district.Id;
            address.NeighborhoodId = neighborhood.Id;
            address.City = city;
            address.District = district;
            address.Neighborhood = neighborhood;

            bool result = await _addressWriteRepository.AddAsync(address);

            if (result)
            {
                return _mapper.Map<GetAddressDto>(address);
            }
            else
            {
                throw new Exception("Failed to add address.");
            }

        }
        public async Task<GetAddressDto> UpsertAsync(string? addressId, CreateAddressDto? dto)
        {
            if (!string.IsNullOrEmpty(addressId))
            {
                var existing = await _addressReadRepository.GetByIdAsync(addressId);
                if (existing == null)
                    throw new Exception($"Address {addressId} not found.");
                return _mapper.Map<GetAddressDto>(existing); ;
            }

            if (dto == null)
                throw new ValidationException("Address details are required when no AddressId is specified.");

            return await AddAddressAsync(dto);

        }

        public async Task<GetAddressDto> UpdateAddressAsync(UpdateAddressDto dto)
        {
            var address = await _addressReadRepository.Table
                .Include(a => a.City)
                .Include(a => a.District)
                .Include(a => a.Neighborhood)
                .FirstOrDefaultAsync(a => a.Id == Guid.Parse(dto.Id))
                ?? throw new BadHttpRequestException("Address couldn't find");

            address = _mapper.Map(dto, address);

            _addressWriteRepository.Update(address);
            
            return _mapper.Map<GetAddressDto>(address);
        }

        public async Task<bool> DeleteAddressAsync(string addressId)
        {
            var address = await _addressReadRepository.GetByIdAsync(addressId);
            
            address.IsDeleted = true;

            return _addressWriteRepository.Update(address);
        }
    }
}
