using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Address.GetCities
{
    public class GetCitiesQueryHandler : IRequestHandler<GetCitiesQueryRequest, List<CityLookupDto>>
    {
        readonly IAddressService _addressService;

        public GetCitiesQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<CityLookupDto>> Handle(GetCitiesQueryRequest request, CancellationToken cancellationToken)
            => _addressService.GetCitiesAsync(cancellationToken);
        
    }
}
