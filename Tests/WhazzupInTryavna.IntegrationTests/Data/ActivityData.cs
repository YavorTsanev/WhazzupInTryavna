namespace WhazzupInTryavna.IntegrationTests.Data
{
    using System;

    using WhazzupInTryavna.Data.Models.Activities;

    public static class ActivityData
    {
        public static Activity GetSingleActivity()
        {
            return new()
            {
                Id = 2,
                Name = "TestName",
                Location = "TestLocation",
                CategoryId = 3,
                StartTime = DateTime.Now,
            };
        }
    }
}
