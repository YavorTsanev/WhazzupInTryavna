namespace WhazzupInTryavna.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Services;

    public class NewsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var newsScraperService = (TryavnaNewsScraperService)serviceProvider.GetService(typeof(ITryavnaNewsScraperService));

            if (dbContext.News.Any())
            {
                return;
            }

            await newsScraperService.ImportNewsAsync();
        }
    }
}
