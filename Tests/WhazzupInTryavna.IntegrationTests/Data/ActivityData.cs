namespace WhazzupInTryavna.IntegrationTests.Data
{
    using System;
    using System.Collections.Generic;

    using MyTested.AspNetCore.Mvc;
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

        public static List<Activity> GetActivities()
        {
            return new()
            {
                new()
                {
                    Id = 3,
                    Name = "TestName3",
                    Location = "TestLocation3",
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
                },
                new()
                {
                    Id = 4,
                    Name = "TestName4",
                    Location = "TestLocation4",
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
                },
            };
        }
    }
}
