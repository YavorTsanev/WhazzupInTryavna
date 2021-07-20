using WhazzupInTryavna.Services.Data.News;
using WhazzupInTryavna.Web.ViewModels.News;

namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Services;

    public class NewsController : Controller
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
    }
}
