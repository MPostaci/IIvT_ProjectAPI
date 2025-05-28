using IIvT_ProjectAPI.Application.DTOs.Address;
using IIvT_ProjectAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.SeedData
{
    public static class SeedDataExtensions
    {
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        // This now only returns the lists—it doesn't call HasData.
        public static (List<City>, List<District>, List<Neighborhood>) LoadTurkishAdminData(this string seedFolder)
        {
            // 1) cities
            var citiesDto = JsonSerializer
                .Deserialize<List<CityDto>>(File.ReadAllText(Path.Combine(seedFolder, "cityList.json")), _jsonOptions)
                ?? new List<CityDto>();

            var cities = citiesDto
                .Select(d => {
                    if (!int.TryParse(d.Code, out var code)) return null;
                    if (string.IsNullOrWhiteSpace(d.Name)) return null;
                    return new City { Id = Guid.NewGuid(), Code = code, Name = d.Name.Trim() };
                })
                .Where(c => c != null)
                .Cast<City>()
                .ToList();

            // 2) districts
            var districtDict = JsonSerializer
                .Deserialize<Dictionary<string, string[]>>(File.ReadAllText(Path.Combine(seedFolder, "districtsByCityCode.json")), _jsonOptions)
                ?? new Dictionary<string, string[]>();

            var districts = new List<District>();
            foreach (var kv in districtDict)
            {
                if (!int.TryParse(kv.Key, out var cityCode)) continue;
                var city = cities.SingleOrDefault(c => c.Code == cityCode);
                if (city == null) continue;
                for (int i = 0; i < kv.Value.Length; i++)
                {
                    var name = kv.Value[i]?.Trim();
                    if (string.IsNullOrWhiteSpace(name)) continue;
                    districts.Add(new District
                    {
                        Id = Guid.NewGuid(),
                        Code = i + 1,
                        Name = name,
                        CityCode = cityCode,
                        CityId = city.Id
                    });
                }
            }

            // 3) neighbourhoods
            var nbDict = JsonSerializer
                .Deserialize<NeighborhoodDto>(File.ReadAllText(Path.Combine(seedFolder, "neighbourhoodsByDistrictAndCityCode.json")), _jsonOptions)
                ?? new NeighborhoodDto();

            var neighbourhoods = new List<Neighborhood>();
            int nextCode = 1;
            foreach (var cityEntry in nbDict)
            {
                if (!int.TryParse(cityEntry.Key, out var cityCode)) continue;
                foreach (var distEntry in cityEntry.Value)
                {
                    var districtName = distEntry.Key?.Trim();
                    if (string.IsNullOrWhiteSpace(districtName)) continue;
                    var district = districts.SingleOrDefault(d =>
                        d.CityCode == cityCode &&
                        d.Name.Equals(districtName, StringComparison.OrdinalIgnoreCase));
                    if (district == null) continue;
                    foreach (var name in distEntry.Value)
                    {
                        var nm = name?.Trim();
                        if (string.IsNullOrWhiteSpace(nm)) continue;
                        neighbourhoods.Add(new Neighborhood
                        {
                            Id = Guid.NewGuid(),
                            Code = nextCode++,
                            Name = nm,
                            DistrictCode = district.Code,
                            DistrictId = district.Id
                        });
                    }
                }
            }

            return (cities, districts, neighbourhoods);
        }
    }

}
