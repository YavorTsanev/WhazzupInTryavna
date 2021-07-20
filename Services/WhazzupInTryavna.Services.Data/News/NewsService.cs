namespace WhazzupInTryavna.Services.Data.News
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;

        public NewsService(IDeletableEntityRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.newsRepository.All().OrderByDescending(x => x.Date).To<T>();
        }

        public T GetById<T>(int newId)
        {
            return this.newsRepository.All().Where(x => x.Id == newId).To<T>().FirstOrDefault();
        }

        public bool IsIdExist(int newsId)
        {
            return this.newsRepository.All().Any(x => x.Id == newsId);
        }
    }
}
