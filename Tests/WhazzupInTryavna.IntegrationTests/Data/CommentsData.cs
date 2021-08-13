using MyTested.AspNetCore.Mvc;
using WhazzupInTryavna.Data.Models.Activities;

namespace WhazzupInTryavna.IntegrationTests.Data
{
    public static class CommentsData
    {
        public static Comment GetComment()
        {
            return new()
            {
                Id = 5,
                ActivityId = 2,
                Content = "TestContent",
                UserId = TestUser.Identifier,
            };
        }
    }
}
