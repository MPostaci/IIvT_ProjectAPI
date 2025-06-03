using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Address.GetNeighborhoodsByDistrictId
{
    public class GetNeighborhoodsByDistrictIdQueryRequest : IRequest<List<NeighborhoodLookupDto>>, IQueryRequest
    {
        public string DistrictId { get; set; }
    }
}