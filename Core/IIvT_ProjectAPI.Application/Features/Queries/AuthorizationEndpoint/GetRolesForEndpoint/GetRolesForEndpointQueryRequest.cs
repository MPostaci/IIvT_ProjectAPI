using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.AuthorizationEndpoint.GetRolesForEndpoint
{
    public class GetRolesForEndpointQueryRequest : IRequest<GetRolesForEndpointQueryResponse>
    {
        public string MenuName { get; set; }
        public string Code { get; set; }
    }
}