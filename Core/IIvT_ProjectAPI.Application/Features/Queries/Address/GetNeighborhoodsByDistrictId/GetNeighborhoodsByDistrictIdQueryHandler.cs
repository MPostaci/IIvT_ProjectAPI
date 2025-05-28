using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Address.GetNeighborhoodsByDistrictId
{
    public class GetNeighborhoodsByDistrictIdQueryHandler : IRequestHandler<GetNeighborhoodsByDistrictIdQueryRequest, List<NeighborhoodLookupDto>>
    {
        readonly IAddressService _addressService;

        public GetNeighborhoodsByDistrictIdQueryHandler(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Task<List<NeighborhoodLookupDto>> Handle(GetNeighborhoodsByDistrictIdQueryRequest request, CancellationToken cancellationToken)
            => _addressService.GetNeighborhoodsByDistrictIdAsync(request.DistrictId, cancellationToken);
    }
}
