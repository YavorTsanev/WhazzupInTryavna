namespace WhazzupInTryavna.Services.Data.News
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Administration.News;

    public interface INewsService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(int newId);

        bool IsIdExist(int newsId);

        Task UpdateByIdAsync(int newsId, NewsAdminEditViewModel model);

        Task DeleteAsync(int newsId);
    }
}
