namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Services.Data.News;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.News;

    public class AdministrationController : AdminBaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
