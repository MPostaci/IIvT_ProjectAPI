using IIvT_ProjectAPI.Application.Common.Marker;
using IIvT_ProjectAPI.Application.DTOs.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Features.Queries.Address.GetDistrictsByCityId
{
    public class GetDistrictsByCityIdQueryRequest : IRequest<List<DistrictLookupDto>>, IQueryRequest
    {
        public string CityId { get; set; }
    }
}
