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
            var adminUser =
                dbContext.Users.FirstOrDefault(x => x.UserName == AdminConst.Username && x.Email == AdminConst.Email);

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var conf = serviceProvider.GetRequiredService<IConfiguration>();

            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    Email = AdminConst.Email,
                    UserName = AdminConst.Username,
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(adminUser, conf["AdminPassword"]);
            }

            await userManager.AddToRoleAsync(adminUser, AdminConst.RoleName);
        }
    }
}
