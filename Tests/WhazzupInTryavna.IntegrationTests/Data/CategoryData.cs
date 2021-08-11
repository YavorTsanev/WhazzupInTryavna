namespace WhazzupInTryavna.IntegrationTests.Data
{
    using WhazzupInTryavna.Data.Models.Activities;

    public static class CategoryData
    {
        public static Category GetCategory()
        {
            return new Category
            {
                Id = 2,
                Name = "Test",
                Image = "testImage.png",
            };
        }
    }
}
