namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Services;
    using WhazzupInTryavna.Services.Data.News;
    using WhazzupInTryavna.Web.Filters;
    using WhazzupInTryavna.Web.ViewModels.News;

    [Authorize]
    public class NewsController : BaseController
    {
        private readonly ITryavnaNewsScraperService newsScraperService;
        private readonly INewsService newsService;

        public NewsController(ITryavnaNewsScraperService newsScraperService, INewsService newsService)
        {
            this.newsScraperService = newsScraperService;
            this.newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            await this.newsScraperService.ImportNewsAsync();

            var model = new NewsListingViewModel
            {
                NewsList = this.newsService.GetAll<NewsInListViewModel>(),
            };

            return this.View(model);
        }

        [CheckNewsId]
        public IActionResult Details(int id)
        {
            var model = this.newsService.GetById<DetailsViewModel>(id);

            return this.View(model);
        }
    }
}
