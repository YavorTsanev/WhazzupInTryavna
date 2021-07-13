namespace WhazzupInTryavna.Services.Data.Activity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Activities;

    public interface IActivityService
    {
       Task CreateAsync(string userid, ActivityAddViewModel model);

       IEnumerable<T> GetAll<T>();

       T GetById<T>(int id);

       bool IsIdExist(int id);

       Task Join(int activityId, string userId);

       Task DisJoin(int activityId, string userId);
    }
}
