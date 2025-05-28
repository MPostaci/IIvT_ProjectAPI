using IIvT_ProjectAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIvT_ProjectAPI.Persistence.SeedData
{
    public static class TurkishAdminDataSeeder
    {
        public static async Task SeedAsync(IIvT_ProjectAPIDbContext context)
        {
            // only seed if empty
            if (await context.Cities.AnyAsync()) return;

            var seedFolder = Path.Combine(AppContext.BaseDirectory, "SeedData");
            var (cities, districts, neighbourhoods) = seedFolder.LoadTurkishAdminData();

            // AddRange and save
            await context.Cities.AddRangeAsync(cities);
            await context.Districts.AddRangeAsync(districts);
            await context.Neighborhoods.AddRangeAsync(neighbourhoods);
            await context.SaveChangesAsync();
        }
    }

}
