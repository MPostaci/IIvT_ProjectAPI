using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Address.GetDistrictsByCityId
{
    public class GetDistrictsByCityIdQueryHandler : IRequestHandler<GetDistrictsByCityIdQueryRequest, List<DistrictLookupDto>>
    {
        readonly IAddressService _addressService;

        public GetDistrictsByCityIdQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<DistrictLookupDto>> Handle(GetDistrictsByCityIdQueryRequest request, CancellationToken cancellationToken)
            => _addressService.GetDistrictsByCityIdAsync(request.CityId, cancellationToken);
    }
}
