namespace WhazzupInTryavna.Web.ViewModels.News
{
    using System;

    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;

    public class NewsInListViewModel : IMapFrom<News>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string ImageUrl { get; set; }
    }
}
