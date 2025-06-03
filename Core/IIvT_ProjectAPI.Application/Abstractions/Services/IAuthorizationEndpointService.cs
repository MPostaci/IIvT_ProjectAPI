using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IAuthorizationEndpointService
    {
        Task AssignRoleToEndpointAsync(string[] roles, string menuName, string code);

        Task<List<string>> GetRolesForEndpointAsync(string menuName, string code);
    }
}
