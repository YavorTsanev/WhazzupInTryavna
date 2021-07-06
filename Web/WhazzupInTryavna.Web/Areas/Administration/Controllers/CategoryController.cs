namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Category;
    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Data.Category;

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
            var model = new CategoryAddViewModel();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddViewModel input)
        {
            if (this.categoryRepository.All().Any(x => x.Name == input.Name))
            {
                this.ModelState.AddModelError(string.Empty, "Name already exist");
                return this.View(input);
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoryService.AddAsync(input);

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

        public IActionResult Edit(int id)
        {
            if (!this.categoryService.CheckId(id))
            {
                return this.NotFound();
            }

            var category = this.categoryService.GetById<CategoryEditViewModel>(id);

            return this.View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CategoryEditViewModel editViewModel)
        {
            var category = this.categoryService.GetById<CategoryEditViewModel>(id);

            if (!this.ModelState.IsValid)
            {
                return this.View(editViewModel);
            }

            await this.categoryService.UpdateById(id, editViewModel);

            return this.RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.categoryService.CheckId(id))
            {
                return this.NotFound();
            }

            await this.categoryService.Delete(id);
            return this.RedirectToAction("All");

        }
    }
}
