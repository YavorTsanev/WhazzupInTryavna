namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Data.Category;
    using WhazzupInTryavna.Web.Filters;
    using WhazzupInTryavna.Web.ViewModels.Administration.Categories;

    public class CategoriesController : AdminBaseController
    {
        private readonly ICategoryService categoryService;
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoriesController(ICategoryService categoryService, IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryService = categoryService;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryFormModel model)
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

            return this.RedirectToAction(nameof(this.All));
        }

        public IActionResult All()
        {
            var categories = new CategoriesListingViewModel
            {
                Categories = this.categoryService.GetAll<CategoryInListViewModel>(),
            };

            return this.View(categories);
        }

        [CheckCategoryId]
        public IActionResult Edit(int id)
        {
            var category = this.categoryService.GetById<CategoryEditViewModel>(id);

            return this.View(category);
        }

        [HttpPost]
        [CheckCategoryId]
        public async Task<IActionResult> Edit(int id, CategoryEditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.categoryService.UpdateByIdAsync(id, model);

            return this.RedirectToAction(nameof(this.All));
        }

        [CheckCategoryId]
        public async Task<IActionResult> Delete(int id)
        {
            await this.categoryService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
