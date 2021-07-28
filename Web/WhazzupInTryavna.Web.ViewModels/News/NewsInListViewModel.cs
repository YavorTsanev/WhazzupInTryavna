namespace WhazzupInTryavna.Web.ViewModels.News
{
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;

    public class NewsInListViewModel : NewsBaseViewModel, IMapFrom<News>
    {
        public int Id { get; set; }
    }
}
