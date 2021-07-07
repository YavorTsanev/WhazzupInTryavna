namespace WhazzupInTryavna.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ActivitiesController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add()
        {
            return this.View();
        }
    }
}
