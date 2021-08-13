using Microsoft.AspNetCore.Identity;
using WhazzupInTryavna.Data.Models;

namespace WhazzupInTryavna.IntegrationTests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
