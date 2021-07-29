using System.Linq;
using WhazzupInTryavna.Services;

namespace WhazzupInTryavna.Data.Seeding
{
    using System;
    using System.Threading.Tasks;


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
