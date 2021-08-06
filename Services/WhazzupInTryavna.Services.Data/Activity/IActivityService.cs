﻿namespace WhazzupInTryavna.Services.Data.Activity
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Activities;

    public interface IActivityService
    {
        Task CreateAsync(string userid, ActivityFormModel model);

        IEnumerable<T> GetAll<T>(string searchTerm, string category, string activities, string userId, string countOfJoins, string timeToStart);

        T GetById<T>(int activityId);

        bool IsIdExist(int activityId);

        Task JoinAsync(int activityId, string userId);

        Task DisJoinAsync(int activityId, string userId);

        Task UpdateAsync(int activityId, ActivityEditViewModel model);

        Task DeleteAsync(int activityId);

        IEnumerable<T> GetAll<T>();
    }
}
