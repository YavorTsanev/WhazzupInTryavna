namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Services.Data.Activity;
    using WhazzupInTryavna.Services.Data.Category;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.Filters;
    using WhazzupInTryavna.Web.ViewModels.Administration.Activities;

    using static WhazzupInTryavna.Common.GlobalConstants;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class ActivitiesController : BaseController
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
            var model = new ActivitiesAdminListingViewModel
            {
                Activities = this.activityService.GetAll<ActivityAdminInListViewModel>(),
            };
            return this.View(model);
        }

        [CheckActivityId]
        public IActionResult Edit(int id)
        {
            var model = this.activityService.GetById<ActivityAdminEditViewModel>(id);
            model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();

            return this.View(model);
        }

        [CheckActivityId]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActivityAdminEditViewModel model)
        {
            if (!this.categoryService.IsIdExist(model.CategoryId))
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), CategoryDontExist);
            }

            if (!this.ModelState.IsValid)
            {
                model.CategoriesItems = this.categoryService.GetAllAsKeyValuePairs();
                return this.View(model);
            }

            await this.activityService.UpdateAsync(id, model);

            this.TempData["AdminUpdatedActivity"] = "Activity updated by admin successfully";

            return this.RedirectToAction(nameof(this.All));
        }

        [CheckActivityId]
        public async Task<IActionResult> Delete(int id)
        {
            await this.activityService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
