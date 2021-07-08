namespace WhazzupInTryavna.Services.Data.Activity
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Activities;

    public interface IActivityService
    {
       Task CreateAsync(string userid, ActivityAddViewModel model);

       IEnumerable<T> GetAll<T>();

       T GetById<T>(int id);
    }
}
