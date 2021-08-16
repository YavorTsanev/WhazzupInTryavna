namespace WhazzupInTryavna.IntegrationTests.Data
{
    using WhazzupInTryavna.Data.Models;

    public static class RolesData
    {
        public static ApplicationRole GetRoles()
        {
            return new()
            {
                Id = "AdminRole",
                Name = "Administrator",
            };
        }
    }
}
