namespace WhazzupInTryavna.Services.Data.Home
{
    using System.Linq;

    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Data.Models.News;

    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Activity> activityRepository;
        private readonly IDeletableEntityRepository<News> newsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public HomeService(IDeletableEntityRepository<Activity> activityRepository, IDeletableEntityRepository<News> newsRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.activityRepository = activityRepository;
            this.newsRepository = newsRepository;
            this.userRepository = userRepository;
        }

        public int ActivitiesCount()
        {
            return this.activityRepository.All().Count();
        }

        public int NewsCount()
        {
            return this.newsRepository.All().Count();
        }

        public int UsersCount()
        {
            return this.userRepository.All().Count();
        }
    }
}
