namespace WhazzupInTryavna.Web.ViewModels.News
{
    using System;

    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;

    public class NewsInListViewModel : NewsBaseViewModel, IMapFrom<News>
    {
        public int Id { get; set; }
    }
}
