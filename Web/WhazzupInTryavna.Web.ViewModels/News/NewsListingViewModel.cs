namespace WhazzupInTryavna.Web.ViewModels.News
{
    using System.Collections.Generic;

    public class NewsListingViewModel
    {
        public IEnumerable<NewsInListViewModel> NewsList { get; set; }
    }
}
