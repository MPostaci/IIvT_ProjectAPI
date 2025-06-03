using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace IIvT_ProjectAPI.Persistence.SeedData
{
    public static class RoleSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<AppRole> roleManager)
        {
            // List out the role names you want to exist
            var roleNames = new[] { "Admin", "EventManager", "User" };

            foreach (var roleName in roleNames)
            {
                // If the role does not yet exist in the database...
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    // 1) Create a new AppRole, explicitly setting Id & NormalizedName
                    var newRole = new AppRole
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = roleName,
                        NormalizedName = roleName.ToUpperInvariant(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()  // best practice
                    };

                    // 2) Pass it into RoleManager.CreateAsync – this calls EF under the hood.
                    var result = await roleManager.CreateAsync(newRole);
                    if (!result.Succeeded)
                    {
                        // If something went wrong, throw so you can see the error immediately
                        var firstError = result.Errors.FirstOrDefault()?.Description;
                        throw new Exception($"Could not create role '{roleName}': {firstError}");
                    }
                }
            }
        }
    }
}
