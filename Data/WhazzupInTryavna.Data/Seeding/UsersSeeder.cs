namespace WhazzupInTryavna.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Data.Models;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var user1 =
                dbContext.Users.FirstOrDefault(x => x.UserName == UsersConst.TestUserName1 && x.Email == UsersConst.TestUser1Email);

            var user2 =
                dbContext.Users.FirstOrDefault(x => x.UserName == UsersConst.TestUserName2 && x.Email == UsersConst.TestUser2Email);

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var conf = serviceProvider.GetRequiredService<IConfiguration>();

            if (user1 == null)
            {
                user1 = new ApplicationUser
                {
                    UserName = UsersConst.TestUserName1,
                    Email = UsersConst.TestUser1Email,
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(user1, conf["TestUser1Password"]);
            }

            if (user2 == null)
            {
                user2 = new ApplicationUser
                {
                    UserName = UsersConst.TestUserName2,
                    Email = UsersConst.TestUser2Email,
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(user2, conf["TestUser2Password"]);
            }
        }
    }
}
