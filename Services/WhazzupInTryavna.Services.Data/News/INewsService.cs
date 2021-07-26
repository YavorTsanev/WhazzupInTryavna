namespace WhazzupInTryavna.Services.Data.News
{
    using System.Collections.Generic;

    public interface INewsService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(int newId);

        bool IsIdExist(int newsId);
    }
}
