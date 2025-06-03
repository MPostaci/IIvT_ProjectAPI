using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Application.Repositories;
using IIvT_ProjectAPI.Domain.Entities;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IIvT_ProjectAPI.Persistence.Services
{
    public class AuthorizationEndpointService : IAuthorizationEndpointService
    {
        readonly IApplicationService _applicationService;
        readonly RoleManager<AppRole> _roleManager;
        readonly IMenuReadRepository _menuReadRepository;
        readonly IMenuWriteRepository _menuWriteRepository;
        readonly IEndpointReadRepository _endpointReadRepository;
        readonly IEndpointWriteRepository _endpointWriteRepository;
        readonly IIdentityRoleEndpointReadRepository _idRoleEndpointReadRepository;
        readonly IIdentityRoleEndpointWriteRepository _idRoleEndpointWriteRepository;

        public AuthorizationEndpointService(IApplicationService applicationService, RoleManager<AppRole> roleManager, IMenuReadRepository menuReadRepository, IMenuWriteRepository menuWriteRepository, IEndpointReadRepository endpointReadRepository, IEndpointWriteRepository endpointWriteRepository, IIdentityRoleEndpointReadRepository idRoleEndpointReadRepository, IIdentityRoleEndpointWriteRepository idRoleEndpointWriteRepository)
        {
            _applicationService = applicationService;
            _roleManager = roleManager;
            _menuReadRepository = menuReadRepository;
            _menuWriteRepository = menuWriteRepository;
            _endpointReadRepository = endpointReadRepository;
            _endpointWriteRepository = endpointWriteRepository;
            _idRoleEndpointReadRepository = idRoleEndpointReadRepository;
            _idRoleEndpointWriteRepository = idRoleEndpointWriteRepository;
        }

        public async Task AssignRoleToEndpointAsync(string[] roles, string menuName, string code)
        {
            var menu = await _menuReadRepository.Table.FirstOrDefaultAsync(m => m.Name == menuName);

            if (menu == null)
            {
                menu = new() { Id = Guid.NewGuid(), Name = menuName };
                await _menuWriteRepository.AddAsync(menu);
            }

            var endpoint = await _endpointReadRepository.Table
                .Include(e => e.IdentityRoleEndpoints)
                .FirstOrDefaultAsync(e => e.Code == code && e.MenuId == menu.Id);

            if (endpoint == null)
            {
                var allMenus = _applicationService.GetAuthorizeDefinitionEndpoints();

                var actionDto = allMenus
                    .FirstOrDefault(m => m.MenuName == menuName)
                    ?.Actions.FirstOrDefault(a => a.Code == code);

                if (actionDto == null)
                    throw new Exception($"Endpoint metadata not found for Menu= '{menuName}', Code='{code}'.");

                endpoint = new Endpoint
                {
                    Id = Guid.NewGuid(),
                    Code = actionDto.Code,
                    HttpType = actionDto.HttpType,
                    ActionType = actionDto.ActionType,
                    Definition = actionDto.Definition,
                    MenuId = menu.Id
                };

                await _endpointWriteRepository.AddAsync(endpoint);
            }

            var existingRoleLinks = endpoint.IdentityRoleEndpoints.ToList();
            _idRoleEndpointWriteRepository.RemoveRange(existingRoleLinks);

            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);

                if (role == null)
                    throw new Exception($"Role '{roleName}' does not exist.");

                var link = new IdentityRoleEndpoint
                {
                    RoleId = role.Id,
                    EndpointId = endpoint.Id,
                };

                await _idRoleEndpointWriteRepository.AddAsync(link);
            }
        }

        public async Task<List<string>> GetRolesForEndpointAsync(string menuName, string code)
        {
            var endpoint = await _endpointReadRepository.Table
                .Include(e => e.IdentityRoleEndpoints)
                    .ThenInclude(j => j.Role)
                .Include(e => e.Menu)
                .FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menuName);

            if (endpoint == null)
                return new();

            return endpoint.IdentityRoleEndpoints
                .Select(j => j.Role.Name)
                .ToList();
        }
    }
}
