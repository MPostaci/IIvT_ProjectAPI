using IIvT_ProjectAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.SeedData
{
    public static class UserSeeder
    {
        public static async Task SeedAdminAsync(UserManager<AppUser> userManager)
        {
            var adminEmail = "admin@admin.com";
            var existing = await userManager.FindByEmailAsync(adminEmail);
            if (existing == null)
            {
                var adminUser = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "superadmin",
                    Email = adminEmail,
                    FullName = "Super Admin"
                };

                var result = await userManager.CreateAsync(adminUser, "P@ssw0rd!");
                if (result.Succeeded)
                {
                    // Now add the just‐created user into the "Admin" role.
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    var firstErr = result.Errors.FirstOrDefault()?.Description;
                    throw new System.Exception($"Could not create admin user: {firstErr}");
                }
            }
        }
    }
}
