using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using DistributeMeProject.Models;

namespace DistributeMeProject.Data
{
    public class SampleData
    {
        public async static Task Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            // Ensure db
            context.Database.EnsureCreated();

            // Ensure Alex (IsAdmin)
            var admin = await userManager.FindByNameAsync("Alex_Liosatos@yahoo.com");
            if (admin == null)
            {
                // create user
                admin = new ApplicationUser
                {
                    UserName = "Alex_Liosatos@yahoo.com",
                    Email = "Alex_Liosatos@yahoo.com"
                };
                await userManager.CreateAsync(admin, "Password81!");

                // add claims
                await userManager.AddClaimAsync(admin, new Claim("IsAdmin", "true"));
                await userManager.AddClaimAsync(admin, new Claim("IsDistributor", "true"));
                await userManager.AddClaimAsync(admin, new Claim("IsRestaurant", "true"));
            }
        }

    }
}
