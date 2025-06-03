using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<IdentityRoleEndpoint> IdentityRoleEndpoints { get; set; } = new List<IdentityRoleEndpoint>();
    }
}
