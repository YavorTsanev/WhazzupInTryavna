using System.Collections.Generic;
using MyTested.AspNetCore.Mvc;

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
                AddedByUserId = TestUser.Username,
                Comments = new List<Comment>
                {
                    new()
                    {
                        Content = "TestContent",
                        ActivityId = 2,
                        UserId = TestUser.Identifier,
                    },
                },
            };
        }
    }
}
