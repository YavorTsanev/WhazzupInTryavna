using System;
using WhazzupInTryavna.Data.Models.Activities;
using WhazzupInTryavna.Web.ViewModels.Activities;

namespace WhazzupInTryavna.IntegrationTests.Data
{

    public static class ActivityData
    {
        public static Activity GetSingleActivity()
        {
            return new Activity
            {
                Id = 2,
                Name = "TestName",
                Location = "TestLocation",
                CategoryId = 2,
                StartTime = DateTime.Now,
            };
        }
    }
}
