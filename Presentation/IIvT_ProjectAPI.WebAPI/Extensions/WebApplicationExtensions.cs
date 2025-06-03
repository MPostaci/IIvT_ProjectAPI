using IIvT_ProjectAPI.Application.Abstractions.Services;
using IIvT_ProjectAPI.Domain.Entities.Identity;
using IIvT_ProjectAPI.Persistence.Context;
using IIvT_ProjectAPI.Persistence.SeedData;
using Microsoft.AspNetCore.Identity;

namespace IIvT_ProjectAPI.WebAPI.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> InitializeDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;

            var db = scope.ServiceProvider.GetRequiredService<IIvT_ProjectAPIDbContext>();
            await TurkishAdminDataSeeder.SeedAsync(db);

            var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
            await RoleSeeder.SeedRolesAsync(roleManager);

            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            await UserSeeder.SeedAdminAsync(userManager);

            var appService = services.GetRequiredService<IApplicationService>();
            var authEndpointSvc = services.GetRequiredService<IAuthorizationEndpointService>();

            var menus = appService.GetAuthorizeDefinitionEndpoints();

            foreach (var menu in menus)
            {
                foreach (var action in menu.Actions)
                {
                    await authEndpointSvc.AssignRoleToEndpointAsync(
                        roles: new string[0],
                        menuName: menu.MenuName,
                        code: action.Code
                        );
                    await db.SaveChangesAsync();
                }

            }

            return app;
        }
    }
}
