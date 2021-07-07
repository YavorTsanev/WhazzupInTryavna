namespace WhazzupInTryavna.Services.Data.Activity
{
    using System.Threading.Tasks;

    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Web.ViewModels.Activities;

    public class ActivityService : IActivityService
    {
        private readonly IDeletableEntityRepository<Activity> activityRepository;
        private readonly IDeletableEntityRepository<UserActivity> userActivityRepository;

        public ActivityService(IDeletableEntityRepository<Activity> activityRepository, IDeletableEntityRepository<UserActivity> userActivityRepository)
        {
            this.activityRepository = activityRepository;
            this.userActivityRepository = userActivityRepository;
        }

        public async Task CreateAsync(string userid, ActivityAddViewModel model)
        {
            var activity = new Activity
            {
                CategoryId = model.CategoryId,
                AddedByUserId = userid,
                Description = model.Description,
                Location = model.Location,
                Name = model.Name,
                StartTime = model.StartTime,
            };

            await this.activityRepository.AddAsync(activity);
            await this.activityRepository.SaveChangesAsync();

            var userActivity = new UserActivity
            {
                UserId = userid,
                Activity = activity,
            };

            await this.userActivityRepository.AddAsync(userActivity);
            await this.userActivityRepository.SaveChangesAsync();
        }
    }
}
