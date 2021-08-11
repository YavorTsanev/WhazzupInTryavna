using System;
using System.Collections.Generic;
using System.Linq;
using WhazzupInTryavna.Data.Models.Activities;

namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Activities;
    using Xunit;
    using static WhazzupInTryavna.IntegrationTests.Data.CategoryData;
    using static WhazzupInTryavna.IntegrationTests.Data.ActivityData;

    public class ActivitiesControllerTests
    {
        [Fact]
        public void GetIndexShouldReturnViewWithModel()
        {
            MyController<ActivitiesController>
                .Instance(x => x.WithUser())
                .Calling(a => a.Index(With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>()))
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivitiesListingViewModel>());
        }

        [Fact]
        public void GetAddShouldReturnView()
        {
            MyController<ActivitiesController>
                .Instance()
                .Calling(a => a.Add())
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityFormModel>());
        }

        [Theory]
        [InlineData(2, "TestName", "2020, 12, 12", "TestLocation")]
        public void PostAddShouldRedirectWithValidModelState(int categoryId, string name, DateTime startTime, string location)
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser()
                    .WithData(GetCategory()))
                .Calling(a => a.Add(new ActivityFormModel
                {
                    CategoryId = categoryId,
                    Name = name,
                    StartTime = startTime,
                    Location = location,
                }))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .Data(data => data.WithSet<Activity>(a => a.Any(a =>
                    a.Id == 1 &&
                    a.CategoryId == categoryId &&
                    a.Name == name &&
                    a.StartTime == startTime &&
                    a.Location == location &&
                    a.AddedByUserId == TestUser.Identifier))
                    .WithSet<UserActivity>(ua => ua.Any(ua =>
                        ua.UserId == TestUser.Identifier &&
                        ua.ActivityId == 1)))
                .AndAlso()
                .ShouldHave()
                .TempData(td => td.ContainingEntryWithKey("AddedActivity"))
                .AndAlso()
                .ShouldReturn()
                .Redirect(r => r.To<ActivitiesController>(c => c.Index(With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>())));
        }

        [Fact]
        public void PostAddShouldReturnViewWithModelWithInvalidModelState()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser())
                .Calling(a => a.Add(new ActivityFormModel()))
                .ShouldHave()
                .InvalidModelState()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityFormModel>());
        }

        [Fact]
        public void GetDetailsShouldReturnViewWithModel()
        {
            MyController<ActivitiesController>
                .Instance()
                .Calling(a => a.Details(2, With.Any<string>()))
                .ShouldReturn()
                .View(v => v.WithModelOfType<SingleActivityViewModel>());
        }
    }
}
