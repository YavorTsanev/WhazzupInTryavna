namespace WhazzupInTryavna.Services.Data.News
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INewsService
    {
        IEnumerable<T> GetAll<T>();

        T GetById<T>(int newId);

        bool IsIdExist(int newsId);
    }
}
