namespace WhazzupInTryavna.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Services.Data.Home;
    using WhazzupInTryavna.Web.ViewModels;
    using WhazzupInTryavna.Web.ViewModels.Home;

    [AllowAnonymous]
    public class HomeController : BaseAuthorizeController
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                ActivitiesCount = this.homeService.ActivitiesCount(),
                NewsCount = this.homeService.NewsCount(),
                UsersCount = this.homeService.UsersCount(),
            };

            return this.View(model);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
