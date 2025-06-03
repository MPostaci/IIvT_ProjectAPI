using IIvT_ProjectAPI.Domain.Entities.Common;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities
{
    public class IdentityRoleEndpoint : BaseEntity
    {
        public string RoleId { get; set; }
        public AppRole Role { get; set; }

        public Guid EndpointId { get; set; }
        public Endpoint Endpoint { get; set; }
    }
}
