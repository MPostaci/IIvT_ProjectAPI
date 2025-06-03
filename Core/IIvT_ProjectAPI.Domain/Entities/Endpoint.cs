
using IIvT_ProjectAPI.Domain.Entities.Common;
using IIvT_ProjectAPI.Domain.Entities.Identity;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class Endpoint : BaseEntity
    {
        public string Code { get; set; }
        public string HttpType { get; set; }
        public string ActionType { get; set; }
        public string Definition { get; set; }

        public Guid MenuId { get; set; }
        public Menu Menu { get; set; }

        public ICollection<IdentityRoleEndpoint> IdentityRoleEndpoints { get; set; } = new List<IdentityRoleEndpoint>();
    }
}
