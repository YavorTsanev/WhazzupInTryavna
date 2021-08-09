namespace WhazzupInTryavna.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WhazzupInTryavna.Data.Models;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class AdminUserSeeder : ISeeder
    {

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.FirstOrDefault(x => x.UserName == AdminConst.Username && x.Email == AdminConst.Email) != null)
            {
                return;
            }

            var adminUser = new ApplicationUser
            {
                Email = AdminConst.Email,
                UserName = AdminConst.Username,
                EmailConfirmed = true,
            };

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await userManager.CreateAsync(adminUser, "123456");
            await userManager.AddToRoleAsync(adminUser, AdminConst.RoleName);
        }
    }
}
