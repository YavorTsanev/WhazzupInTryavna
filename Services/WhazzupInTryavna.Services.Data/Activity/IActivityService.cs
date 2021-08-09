namespace WhazzupInTryavna.Services.Data.Activity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Activities;

    public interface IActivityService
    {
        Task CreateAsync(string userid, ActivityFormModel model);

        IEnumerable<T> GetAll<T>(string searchTerm = null, string category = null, string activities = null, string userId = null, string countOfJoins = null, string timeToStart = null);

        T GetById<T>(int activityId);

        bool IsIdExist(int activityId);

        Task JoinAsync(int activityId, string userId);

        Task DisJoinAsync(int activityId, string userId);

        Task UpdateAsync(int activityId, ActivityEditViewModel model);

        Task DeleteAsync(int activityId);
    }
}
