using IIvT_ProjectAPI.Application.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Application.Abstractions.Services
{
    public interface IRoleService
    {
        Task<PagedResponse<IDictionary<string, string>>> GetAllRoles(PagedRequest pagedRequest);

        Task<(string id, string name)> GetRoleById(string id);

        Task<bool> CreateRole(string name);

        Task<bool> UpdateRole(string id, string name);
        
        Task<bool> DeleteRole(string idOrName);

    }
}
