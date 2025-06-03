using AutoMapper;
using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Common.Pagination;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class RoleService : IRoleService
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IDictionary<string, string>>> GetAllRoles(PagedRequest pagedRequest)
            => await _roleManager.Roles.ToPagedListAsync<AppRole, IDictionary<string, string>>(_mapper ,pagedRequest);

        public async Task<(string id, string name)> GetRoleById(string id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);

            return new()
            {
                id = role.Id,
                name = role.Name
            };
        }

        public async Task<bool> CreateRole(string name)
        {
            var result = await _roleManager.CreateAsync(new AppRole() { Id = Guid.NewGuid().ToString(), Name = name });

            return result.Succeeded;
        }

        public async Task<bool> DeleteRole(string idOrName)
        {
            var role = await _roleManager.FindByIdAsync(idOrName)
                ?? await _roleManager.FindByNameAsync(idOrName)
                ?? throw new Exception($"There is not a role that has {idOrName} id or name");

            var result = await _roleManager.DeleteAsync(role);

            return result.Succeeded;
        }

        public async Task<bool> UpdateRole(string id, string name)
        {
            var role = await _roleManager.FindByIdAsync(id)
                ?? throw new Exception($"There is not a role that has {id} id");

            role.Name = name;

            var result = await _roleManager.UpdateAsync(role);

            return result.Succeeded;
        }
    }
}
