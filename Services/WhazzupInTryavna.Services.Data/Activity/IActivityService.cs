namespace WhazzupInTryavna.Services.Data.Activity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Activities;

    public interface IActivityService
    {
       Task CreateAsync(string userid, ActivityAddViewModel model);

       IEnumerable<T> GetAll<T>(string category, string participant, string userId, string timeToStart);

       T GetById<T>(int activityId);

       bool IsIdExist(int activityId);

       Task Join(int activityId, string userId);

       Task DisJoin(int activityId, string userId);

       Task UpdateAsync(int activityId, ActivityEditViewModel model);

       Task Delete(int activityId);
    }
}
