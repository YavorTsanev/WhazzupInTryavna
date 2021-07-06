namespace WhazzupInTryavna.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Administration.Category;

    public interface ICategoryService
    {
        Task AddAsync(CategoryAddViewModel model);

        ICollection<T> GetAll<T>();

        T GetById<T>(int id);

        Task UpdateById(int id, CategoryEditViewModel editViewModel);

        Task Delete(int id);

        bool CheckId(int id);
    }
}
