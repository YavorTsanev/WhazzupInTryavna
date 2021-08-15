using System.Collections.Generic;

namespace WhazzupInTryavna.IntegrationTests.Data
{
    using WhazzupInTryavna.Data.Models.Activities;

    public static class CategoryData
    {
        public static Category GetSingleCategory()
        {
            return new()
            {
                Id = 3,
                Name = "Test",
                Image = "testImage.png",
                Activities = new List<Activity>(5),
            };
        }

        public static List<Category> GetCategories()
        {
            return new()
            {
                new()
                {
                    Id = 3,
                    Name = "Test3",
                    Image = "testImage3.png",
                    Activities = new List<Activity>(5),
                },
                new()
                {
                    Id = 10,
                    Name = "Test10",
                    Image = "testImage10.png",
                    Activities = new List<Activity>(5),
                },
            };
        }
    }
}
