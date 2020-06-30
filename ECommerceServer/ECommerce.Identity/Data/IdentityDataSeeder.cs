using System;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Identity.Data.Models;
using ECommerce.Identity.Services;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Identity.Data
{
    public class IdentityDataSeeder: IDataSeeder
    {

        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityDataSeeder(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedData()
        {
            if (this.roleManager.Roles.Any())
            {
                return;
            }

            Task
                .Run(async () =>
                {
                    var adminRole = new IdentityRole(ECommerce.Common.Constants.AdministratorRoleName);

                    await this.roleManager.CreateAsync(adminRole);

                    var adminUser = new User
                    {
                        UserName = "test@abv.bg",
                        Email = "test@abv.bg",
                        SecurityStamp = "RandomSecurityStamp"
                    };

                    await userManager.CreateAsync(adminUser, "123456");

                    await userManager.AddToRoleAsync(adminUser, ECommerce.Common.Constants.AdministratorRoleName);
                })
                .GetAwaiter()
                .GetResult();
        }

    }
}
