namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Data.Category;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Category;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class CategoryController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryController(ICategoryService categoryService, IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryService = categoryService;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddViewModel model)
        {
            if (this.categoryRepository.All().Any(x => x.Name == model.Name))
            {
                this.ModelState.AddModelError(string.Empty, "Name already exist");
                return this.View(model);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.categoryService.AddAsync(model);

            return this.RedirectToAction("All");
        }

        public IActionResult All()
        {
            var categories = new CategoryListViewModel
            {
                Categories = this.categoryService.GetAll<CategoryInListViewModel>(),
            };

            return this.View(categories);
        }

        [CheckId]
        public IActionResult Edit(int id)
        {
            var category = this.categoryService.GetById<CategoryEditViewModel>(id);

            return this.View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.categoryService.UpdateById(id, model);

            return this.RedirectToAction("All");
        }

        [CheckId]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.categoryService.Delete(id);
            return this.RedirectToAction("All");
        }
    }
}
