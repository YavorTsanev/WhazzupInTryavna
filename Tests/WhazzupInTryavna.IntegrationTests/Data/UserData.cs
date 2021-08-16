namespace WhazzupInTryavna.IntegrationTests.Data
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using WhazzupInTryavna.Data.Models;

    public static class UserData
    {
        public static List<ApplicationUser> GetUsers()
        {
            return new()
            {
                new ApplicationUser
                {
                    Id = "AdminUser",
                    Roles = new List<IdentityUserRole<string>>
                    {
                        new()
                        {
                            RoleId = "AdminRole",
                            UserId = "AdminUser",
                        },
                    },
                },
                new ApplicationUser
                {
                    Id = "TestAppUser",
                },
            };
        }
    }
}
