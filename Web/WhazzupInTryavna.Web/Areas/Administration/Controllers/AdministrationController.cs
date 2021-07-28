namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AdministrationController : AdminBaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
