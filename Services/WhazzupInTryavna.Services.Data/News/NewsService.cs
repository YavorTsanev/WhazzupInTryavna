using System;
using System.Linq;

namespace WhazzupInTryavna.Services.Data.News
{
    using System.Collections.Generic;

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
    }
}
