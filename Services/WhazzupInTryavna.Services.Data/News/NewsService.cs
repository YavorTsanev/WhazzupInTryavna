namespace WhazzupInTryavna.Services.Data.News
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Extensions.Caching.Memory;
    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Mapping;
    using WhazzupInTryavna.Web.ViewModels.Administration.News;

    public class NewsService : INewsService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;
        private readonly IMemoryCache memoryCache;

        public NewsService(IDeletableEntityRepository<News> newsRepository, IMemoryCache memoryCache)
        {
            this.newsRepository = newsRepository;
            this.memoryCache = memoryCache;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.newsRepository.All().OrderByDescending(x => x.Date).To<T>().ToList();
        }

        public T GetById<T>(int newId)
        {
            return this.newsRepository.All().Where(x => x.Id == newId).To<T>().FirstOrDefault();
        }

        public bool IsIdExist(int newsId)
        {
            return this.newsRepository.All().Any(x => x.Id == newsId);
        }

        public async Task UpdateByIdAsync(int newsId, NewsAdminEditViewModel model)
        {
            var newsToUpdate = this.GetById(newsId);

            newsToUpdate.Date = model.Date;
            newsToUpdate.Content = model.Content;
            newsToUpdate.ImageUrl = model.ImageUrl;
            newsToUpdate.Title = model.Title;

            await this.newsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int newsId)
        {
            var newsToDelete = this.GetById(newsId);

            this.newsRepository.Delete(newsToDelete);

            await this.newsRepository.SaveChangesAsync();
        }

        private News GetById(int id)
        {
            return this.newsRepository.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
