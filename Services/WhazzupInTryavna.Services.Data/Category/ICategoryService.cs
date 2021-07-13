namespace WhazzupInTryavna.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Administration.Category;

    public interface ICategoryService
    {
        Task AddAsync(CategoryAddViewModel model);

        ICollection<T> GetAll<T>();

        T GetById<T>(int categoryId);

        Task UpdateById(int categoryId, CategoryEditViewModel editViewModel);

        Task Delete(int categoryId);

        bool IsIdExist(int categoryId);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
