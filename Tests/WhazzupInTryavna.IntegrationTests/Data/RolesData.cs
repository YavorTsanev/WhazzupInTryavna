using WhazzupInTryavna.Data.Models;

namespace WhazzupInTryavna.IntegrationTests.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class RolesData
    {
        public static ApplicationRole GetRoles()
        {
            return new ApplicationRole()
            {
                Id = "AdminRole",
                Name = "Administrator",
            };
        }
    }
}
