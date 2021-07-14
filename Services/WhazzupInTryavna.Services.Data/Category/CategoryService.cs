namespace WhazzupInTryavna.Services.Data.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;
    using WhazzupInTryavna.Web.ViewModels.Administration.Category;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task AddAsync(CategoryAddViewModel model)
        {
            var category = new Category
            {
                Name = model.Name,
                CreatedOn = DateTime.UtcNow,
                Image = model.Image,
            };

            await this.categoryRepository.AddAsync(category);
            await this.categoryRepository.SaveChangesAsync();
        }

        public ICollection<T> GetAll<T>()
        {
            return this.categoryRepository.All().To<T>().ToList();
        }

        public T GetById<T>(int categoryId)
        {
            return this.categoryRepository.All().Where(x => x.Id == categoryId).To<T>().FirstOrDefault();
        }

        public async Task UpdateById(int categoryId, CategoryEditViewModel editViewModel)
        {
            var category = this.GetById(categoryId);
            category.Image = editViewModel.Image;
            category.Name = editViewModel.Name;
            await this.categoryRepository.SaveChangesAsync();
        }

        public async Task Delete(int categoryId)
        {
            var category = this.GetById(categoryId);
            this.categoryRepository.Delete(category);
            await this.categoryRepository.SaveChangesAsync();
        }

        public bool IsIdExist(int categoryId)
        {
            return this.categoryRepository.All().Any(x => x.Id == categoryId);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.categoryRepository.All().Select(x => new { x.Id, x.Name }).OrderBy(x => x.Name).ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<string> GetAllCategoryNames()
        {
            var result =  this.categoryRepository.All().Select(x => x.Name).OrderBy(x => x).ToList();
            result.Add("All");
            return result;
        }

        private Category GetById(int categoryId)
        {
            return this.categoryRepository.All().FirstOrDefault(x => x.Id == categoryId);
        }
    }
}
