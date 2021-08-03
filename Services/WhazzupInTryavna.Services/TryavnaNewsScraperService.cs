namespace WhazzupInTryavna.Services
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using System.Threading.Tasks;

    using AngleSharp;
    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.News;
    using WhazzupInTryavna.Services.Models;

    public class TryavnaNewsScraperService : ITryavnaNewsScraperService
    {
        private readonly IDeletableEntityRepository<News> newsRepository;
        private readonly IConfiguration config;
        private readonly IBrowsingContext context;

        public TryavnaNewsScraperService(IDeletableEntityRepository<News> newsRepository)
        {
            this.newsRepository = newsRepository;
            this.config = Configuration.Default.WithDefaultLoader();
            this.context = BrowsingContext.New(this.config);
        }

        public async Task ImportNewsAsync(int count = 10)
        {
            var newsDtos = await this.FetchNews(count);
            var orderedNewsDtos = newsDtos.OrderByDescending(x => x.Date);

            foreach (var newsDto in orderedNewsDtos)
            {
                if (this.newsRepository.All().Any(x => x.Content == newsDto.Content))
                {
                    return;
                }

                var news = new News
                {
                    Title = newsDto.Title,
                    Date = newsDto.Date,
                    ImageUrl = newsDto.ImageUrl,
                    Content = newsDto.Content,
                };

                await this.newsRepository.AddAsync(news);
                await this.newsRepository.SaveChangesAsync();
            }
        }

        private async Task<ConcurrentBag<NewsDto>> FetchNews(int count)
        {
            var newsDtos = new ConcurrentBag<NewsDto>();

            var tryavnaWebSite = await this.context.OpenAsync("https://tryavna.bg/aktualno/novini/");

            Parallel.For(1, count, (i) =>
            {
                var linkNews = tryavnaWebSite.QuerySelector($"#wrapper > section.mt-4 > div > div:nth-child(1) > div:nth-child({i}) > div > a").GetAttribute("href");

                var news = this.context.OpenAsync(linkNews).GetAwaiter().GetResult();

                var newsHeader = news.GetElementsByTagName("h1")[0].InnerHtml;

                var newsDate = news.QuerySelector(".lead").TextContent.Trim();

                var newsContentCollection = news.GetElementsByTagName("p");

                if (!newsContentCollection.Any(p => p.TextContent.Length < 1))
                {
                    try
                    {
                        var newsImgUrl = news.QuerySelector(".post-image").Attributes[1].Value;

                        string newsContent = null;

                        foreach (var item in newsContentCollection.Skip(1).SkipLast(2))
                        {
                            newsContent += item.TextContent.Trim();
                        }

                        var newsDto = new NewsDto
                        {
                            Title = newsHeader,
                            Date = DateTime.Parse(newsDate),
                            ImageUrl = newsImgUrl,
                            Content = newsContent,
                        };

                        newsDtos.Add(newsDto);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            });

            return newsDtos;
        }
    }
}
