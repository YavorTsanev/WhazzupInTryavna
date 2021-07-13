namespace WhazzupInTryavna.Services.Data.Category
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models;
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

        public T GetById<T>(int id)
        {
            return this.categoryRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
        }

        public async Task UpdateById(int id, CategoryEditViewModel editViewModel)
        {
            var category = this.GetById(id);
            category.Image = editViewModel.Image;
            category.Name = editViewModel.Name;
            await this.categoryRepository.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = this.GetById(id);
            this.categoryRepository.Delete(category);
            await this.categoryRepository.SaveChangesAsync();
        }

        public bool IsIdExist(int id)
        {
            return this.categoryRepository.All().Any(x => x.Id == id);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.categoryRepository.All().Select(x => new {x.Id, x.Name}).OrderBy(x => x.Name).ToList()
                .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        private Category GetById(int id)
        {
           return this.categoryRepository.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
