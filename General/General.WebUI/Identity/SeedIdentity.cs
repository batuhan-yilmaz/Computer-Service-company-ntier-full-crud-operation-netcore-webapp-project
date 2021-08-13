using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace General.WebUI.Identity
{
    public static class SeedIdentity
    {

        public static async Task Seed(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"];
            var mail = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];
            if (await userManager.FindByNameAsync(username) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));

                var user = new ApplicationUser()
                {
                    UserName = username,
                    Email = mail,
                    FullName = "Admin User",
                    BirthDate = "19.04.1991",
                    RegisterDate = "11.04.2021",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

        }

    }
}
