namespace WhazzupInTryavna.Services.Data.Activity
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;
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

        public IEnumerable<T> GetAll<T>(string category, string participants, string userId)
        {
            var query = this.activityRepository.All();

            if (category != "All" && category != null)
            {
                query = query.Where(x => x.Category.Name == category);
            }

            query = participants switch
            {
                "All" => query,
                "My activities" => query.Where(x => x.UserActivities.Any(a => a.UserId == userId)),
                "With the less participants" => query.OrderBy(x => x.UserActivities.Count),
                "With the most participants" => query.OrderByDescending(x => x.UserActivities.Count),
                _ => this.activityRepository.All(),
            };

            return query.To<T>().ToList();
        }

        public T GetById<T>(int activityId)
        {
            return this.activityRepository.All().Where(x => x.Id == activityId).To<T>().FirstOrDefault();
        }

        public bool IsIdExist(int activityId)
        {
            return this.activityRepository.All().Any(x => x.Id == activityId);
        }

        public async Task Join(int activityId, string userId)
        {
            var userActivity = new UserActivity
            {
                ActivityId = activityId,
                UserId = userId,
            };

            await this.userActivityRepository.AddAsync(userActivity);
            await this.activityRepository.SaveChangesAsync();
        }

        public async Task DisJoin(int activityId, string userId)
        {
            var userActivity = this.userActivityRepository.All()
                .FirstOrDefault(x => x.ActivityId == activityId && x.UserId == userId);

            if (userActivity != null)
            {
                this.userActivityRepository.Delete(userActivity);
                await this.userActivityRepository.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(int activityId, ActivityEditViewModel model)
        {
            var activity = this.GetActivityById(activityId);

            activity.StartTime = model.StartTime;
            activity.CategoryId = model.CategoryId;
            activity.Description = model.Description;
            activity.Location = model.Location;
            activity.Name = model.Name;
            await this.activityRepository.SaveChangesAsync();
        }

        public async Task Delete(int activityId)
        {
            var activity = this.GetActivityById(activityId);

            this.activityRepository.Delete(activity);
            await this.activityRepository.SaveChangesAsync();
        }

        private Activity GetActivityById(int id)
        {
            return this.activityRepository.All().FirstOrDefault(x => x.Id == id);
        }
    }
}
