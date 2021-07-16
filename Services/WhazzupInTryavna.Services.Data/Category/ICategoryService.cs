namespace WhazzupInTryavna.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Administration.Categories;

    public interface ICategoryService
    {
        Task AddAsync(CategoryAddViewModel model);

        ICollection<T> GetAll<T>();

        T GetById<T>(int categoryId);

        Task UpdateByIdAsync(int categoryId, CategoryEditViewModel editViewModel);

        Task DeleteAsync(int categoryId);

        bool IsIdExist(int categoryId);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<string> GetAllCategoryNames();
    }
}
