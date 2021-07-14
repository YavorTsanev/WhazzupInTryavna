using System.Linq;
using WhazzupInTryavna.Data.Common.Repositories;
using WhazzupInTryavna.Data.Models.Activities;

namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Services.Data.Activity;
    using WhazzupInTryavna.Services.Data.Category;
    using WhazzupInTryavna.Web.Filters;
    using WhazzupInTryavna.Web.ViewModels.Activities;

    [Authorize]
    public class ActivitiesController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IActivityService activityService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<UserActivity> userActivityRepository;

        public ActivitiesController(ICategoryService categoryService, IActivityService activityService, UserManager<ApplicationUser> userManager, IDeletableEntityRepository<UserActivity> userActivityRepository)
        {
            this.categoryService = categoryService;
            this.activityService = activityService;
            this.userManager = userManager;
            this.userActivityRepository = userActivityRepository;
        }

        public IActionResult Index(string category)
        {
            var model = new ActivitiesListViewModel
            {
                Categories = this.categoryService.GetAllCategoryNames(),
                Activities = this.activityService.GetAll<ActivityInListViewModel>(category),
            };

            return this.View(model);
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
            if (!this.categoryService.IsIdExist(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category don't exist");
            }

            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(model);
            }

            var userid = this.GetUserId();

            await this.activityService.CreateAsync(userid, model);

            this.TempData["AddedActivity"] = "Activity added successfully";

            return this.Redirect("/Activities/Index");
        }

        [CheckActivityId]
        public IActionResult Details(int id)
        {
            var model = this.activityService.GetById<SingleActivityViewModel>(id);

            return this.View(model);
        }

        [CheckActivityId]
        public async Task<IActionResult> Join(int id)
        {
            var userId = this.GetUserId();

            if (this.userActivityRepository.All().Any(x => x.ActivityId == id && x.UserId == userId))
            {
                return this.RedirectToAction("Details", new { id });
            }

            await this.activityService.Join(id, userId);

            return this.RedirectToAction("Details", new { id });
        }

        [CheckActivityId]
        public async Task<IActionResult> DisJoin(int id)
        {
            var userId = this.GetUserId();

            await this.activityService.DisJoin(id, userId);

            return this.RedirectToAction("Details", new { id });
        }

        [CheckActivityId]
        public IActionResult Edit(int id)
        {
            var model = this.activityService.GetById<ActivityEditViewModel>(id);
            model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();

            return this.View(model);
        }

        [HttpPost]
        [CheckActivityId]
        public async Task<IActionResult> Edit(int id, ActivityEditViewModel model)
        {
            if (!this.categoryService.IsIdExist(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Category don't exist");
            }

            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(model);
            }

            await this.activityService.UpdateAsync(id, model);

            this.TempData["UpdatedActivity"] = "Activity updated successfully";

            return this.RedirectToAction("Details", new { id });
        }

        [CheckActivityId]
        public async Task<IActionResult> Delete(int id)
        {
            await this.activityService.Delete(id);

            return this.RedirectToAction("Index");
        }

        private string GetUserId()
        {
            return this.userManager.GetUserId(this.User);
        }
    }
}
