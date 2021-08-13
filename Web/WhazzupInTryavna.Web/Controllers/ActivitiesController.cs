namespace WhazzupInTryavna.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Data.Activity;
    using WhazzupInTryavna.Services.Data.Category;
    using WhazzupInTryavna.Web.Filters;
    using WhazzupInTryavna.Web.Infrastructure;
    using WhazzupInTryavna.Web.ViewModels.Activities;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class ActivitiesController : BaseAuthorizeController
    {
        private readonly ICategoryService categoryService;
        private readonly IActivityService activityService;
        private readonly IDeletableEntityRepository<UserActivity> userActivityRepository;

        public ActivitiesController(ICategoryService categoryService, IActivityService activityService, IDeletableEntityRepository<UserActivity> userActivityRepository)
        {
            this.categoryService = categoryService;
            this.activityService = activityService;
            this.userActivityRepository = userActivityRepository;
        }

        public IActionResult Index(string searchTerm, string category, string activity, string countOfJoins, string timeToStart)
        {
            var userId = this.User.GetId();

            var model = new ActivitiesListingViewModel
            {
                Categories = this.categoryService.GetAllCategoryNames(),
                Activities = this.activityService.GetAll<ActivityInListViewModel>(searchTerm, category, activity, userId, countOfJoins, timeToStart),
            };

            return this.View(model);
        }

        public IActionResult Add()
        {
            var model = new ActivityFormModel
            {
                CategoriesItems = this.categoryService.GetAllAsKeyValuePairs(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActivityFormModel model)
        {
            if (!this.categoryService.IsIdExist(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), ErrorMessageConst.CategoryDontExist);
            }

            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(model);
            }

            var userid = this.User.GetId();

            await this.activityService.CreateAsync(userid, model);

            this.TempData["AddedActivity"] = "Activity added successfully";

            return this.RedirectToAction(nameof(this.Index));
        }

        [CheckActivityId]
        public IActionResult Details(int id, string information)
        {
            var model = this.activityService.GetById<SingleActivityViewModel>(id);

            if (information != model.GetInformation())
            {
                return this.BadRequest();
            }

            return this.View(model);
        }

        [CheckActivityId]
        public async Task<IActionResult> Join(int id, string information)
        {
            var userId = this.User.GetId();

            if (this.userActivityRepository.All().Any(x => x.ActivityId == id && x.UserId == userId))
            {
                return this.RedirectToAction(nameof(this.Details), new { id, information });
            }

            await this.activityService.JoinAsync(id, userId);

            return this.RedirectToAction(nameof(this.Details), new { id, information });
        }

        [CheckActivityId]
        public async Task<IActionResult> DisJoin(int id, string information)
        {
            var userId = this.User.GetId();

            await this.activityService.DisJoinAsync(id, userId);

            return this.RedirectToAction(nameof(this.Details), new { id, information });
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
                this.ModelState.AddModelError(nameof(model.CategoryId), ErrorMessageConst.CategoryDontExist);
            }

            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(model);
            }

            await this.activityService.UpdateAsync(id, model);

            var information = model.GetInformation();

            this.TempData["UpdatedActivity"] = "Activity updated successfully";

            return this.RedirectToAction(nameof(this.Details), new { id, information });
        }

        [CheckActivityId]
        public async Task<IActionResult> Delete(int id)
        {
            await this.activityService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}
