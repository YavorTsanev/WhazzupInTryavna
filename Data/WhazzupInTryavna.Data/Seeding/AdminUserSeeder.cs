using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhazzupInTryavna.Common;
using WhazzupInTryavna.Data.Models;
using static WhazzupInTryavna.Common.GlobalConstants;

namespace WhazzupInTryavna.Data.Seeding
{
    public class AdminUserSeeder : ISeeder
    {
        private readonly IConfiguration configuration;

        public AdminUserSeeder(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.FirstOrDefault(x => x.UserName == AdminUsername && x.Email == AdminEmail) != null)
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                Email = AdminEmail,
                UserName = AdminUsername,
            };

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await userManager.CreateAsync(adminUser, this.configuration["AdminPassword"]);
            await userManager.AddToRoleAsync(adminUser, GlobalConstants.AdministratorRoleName);
        }
    }
}
