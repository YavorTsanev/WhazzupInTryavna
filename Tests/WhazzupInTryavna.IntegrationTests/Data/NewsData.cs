namespace WhazzupInTryavna.IntegrationTests.Data
{
    using System;

    using WhazzupInTryavna.Data.Models.News;

    public static class NewsData
    {
        public static News GetNews()
        {
            return new()
            {
                Id = 5,
                Content = "NewsContent",
                Date = new DateTime(2021, 8, 13),
                ImageUrl = "News.png",
                Title = "NewsTitle",
            };
        }
    }
}
