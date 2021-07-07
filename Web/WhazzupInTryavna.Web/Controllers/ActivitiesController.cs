namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Services.Data.Activity;
    using WhazzupInTryavna.Services.Data.Category;
    using WhazzupInTryavna.Web.ViewModels.Activities;

    public class ActivitiesController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IActivityService activityService;
        private readonly UserManager<ApplicationUser> userManager;

        public ActivitiesController(ICategoryService categoryService, IActivityService activityService, UserManager<ApplicationUser> userManager)
        {
            this.categoryService = categoryService;
            this.activityService = activityService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Add()
        {
            var model = new ActivityAddViewModel();
            model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActivityAddViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(model);
            }

            var userid = this.userManager.GetUserId(this.User);

            await this.activityService.CreateAsync(userid, model);

            return this.Redirect("/Activities/Index");
        }
    }
}
