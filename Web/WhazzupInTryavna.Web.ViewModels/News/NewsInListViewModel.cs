namespace WhazzupInTryavna.Web.ViewModels.News
{
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;

    public class NewsInListViewModel : IMapFrom<News>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }
    }
}
