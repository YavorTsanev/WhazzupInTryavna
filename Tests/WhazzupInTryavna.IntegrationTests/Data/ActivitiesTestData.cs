

using System;
using System.Linq;
using MyTested.AspNetCore.Mvc;
using WhazzupInTryavna.Data.Models;

namespace WhazzupInTryavna.IntegrationTests.Data
{
    using WhazzupInTryavna.Web.ViewModels.Activities;

    public static class ActivitiesTestData
    {
        public static ActivitiesListingViewModel GetActivities(string searchTerm, string category, string activity, string countOfJoins, string timeToStart)
        {
            var user = new ApplicationUser
            {
                Id = TestUser.Identifier,
                UserName = TestUser.Username,
            };

            var activities = new ActivitiesListingViewModel
            {
                Category = category,
                Activity = activity,
                CountOfJoins = countOfJoins,
                SearchTerm = searchTerm,
                TimeToStart = timeToStart,
                Activities = Enumerable.Range(1, 10).Select(i => new ActivityInListViewModel
                {
                    Id = i,
                    CategoryImage = "Activity.png",
                    CommentsCount = i,
                    Location = $"location{i}",
                    Name = $"name{i}",
                    StartTime = DateTime.Now,
                }).ToList(),
                Categories = Enumerable.Range(1, 10).Select(i => i.ToString()).ToList(),
            };

            return activities;
        }
    }
}
