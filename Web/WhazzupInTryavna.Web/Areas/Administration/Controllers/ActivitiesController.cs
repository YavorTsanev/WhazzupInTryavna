using System.Threading.Tasks;

namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Services.Data.Activity;
    using WhazzupInTryavna.Services.Data.Category;
    using WhazzupInTryavna.Web.ViewModels.Administration.Activities;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ActivitiesController : Controller
    {
        private readonly IActivityService activityService;
        private readonly ICategoryService categoryService;

        public ActivitiesController(IActivityService activityService, ICategoryService categoryService)
        {
            this.activityService = activityService;
            this.categoryService = categoryService;
        }

        public IActionResult All()
        {
            var model = new ActivityAdminListingViewModel
            {
                Activities = this.activityService.GetAll<ActivityAdminInListViewModel>(),
            };
            return this.View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = this.activityService.GetById<ActivityAdminEditViewModel>(id);
            model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActivityAdminEditViewModel model)
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

            this.TempData["AdminUpdatedActivity"] = "Activity updated by admin successfully";

            return this.RedirectToAction("All");
        }
    }
}
