using IIvT_ProjectAPI.Application.Common.Marker;
using MediatR;

namespace IIvT_ProjectAPI.Application.Features.Queries.Role.GetRoleById
{
    public class GetRoleByIdQueryRequest : IRequest<(string id, string name)>, IQueryRequest
    {
        public string Id { get; set; }
    }
}