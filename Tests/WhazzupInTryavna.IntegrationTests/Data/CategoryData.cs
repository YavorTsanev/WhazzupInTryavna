using System.Collections.Generic;

namespace WhazzupInTryavna.IntegrationTests.Data
{
    using WhazzupInTryavna.Data.Models.Activities;

    public static class CategoryData
    {
        public static Category GetCategory()
        {
            return new()
            {
                Id = 3,
                Name = "Test",
                Image = "testImage.png",
                Activities = new List<Activity>(5),
            };
        }
    }
}
