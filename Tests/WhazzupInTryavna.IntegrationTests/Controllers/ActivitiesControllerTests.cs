namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using System;
    using System.Linq;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Activities;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.ActivityData;
    using static WhazzupInTryavna.IntegrationTests.Data.CategoryData;

    public class ActivitiesControllerTests
    {
        [Fact]
        public void GetIndexShouldReturnViewWithCorrectModel()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser()
                    .WithData(GetSingleCategory())
                    .WithData(GetSingleActivity()))
                .Calling(a => a.Index(With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>()))
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivitiesListingViewModel>()
                    .Passing(x => x.Categories.Any(c =>
                        c == "Test") &&
                                  x.Activities.Any(a =>
                                      a.Name == "TestName")));
        }

        [Fact]
        public void GetAddShouldReturnViewWithModel()
        {
            MyController<ActivitiesController>
                .Instance()
                .Calling(a => a.Add())
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityFormModel>());
        }

        [Theory]
        [InlineData(3, "TestName", "2020, 12, 12", "TestLocation")]
        public void PostAddShouldRedirectWithValidModelState(int categoryId, string name, DateTime startTime, string location)
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser()
                    .WithData(GetSingleCategory()))
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
                .Data(data => data.WithSet<Activity>(x => x.Any(a =>
                        a.Id == 1 &&
                        a.CategoryId == categoryId &&
                        a.Name == name &&
                        a.StartTime == startTime &&
                        a.Location == location &&
                        a.AddedByUserId == TestUser.Identifier))
                    .WithSet<UserActivity>(x => x.Any(ua =>
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
        public void PostAddShouldReturnViewWithCorrectModelWithInvalidModelState()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser())
                .Calling(a => a.Add(new ActivityFormModel
                {
                    Name = string.Empty,
                }))
                .ShouldHave()
                .InvalidModelState()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityFormModel>()
                    .Passing(x => x.Name == string.Empty));
        }

        ////[Fact]
        ////public void GetDetailsShouldReturnViewWithModel()
        ////{
        ////    MyController<ActivitiesController>
        ////        .Instance(x => x
        ////            .WithUser()
        ////            .WithData(new Category
        ////            {
        ////                Id = 4,
        ////                Name = "Test",
        ////                Image = "testImage.png",
        ////                Activities = new List<Activity>(5),
        ////            })
        ////            .WithData(new Activity
        ////            {
        ////                Id = 6,
        ////                Name = "TestName",
        ////                Location = "TestLocation",
        ////                CategoryId = 4,
        ////                StartTime = DateTime.Now,
        ////            })
        ////            .WithData(new UserActivity
        ////            {
        ////                Id = 1,
        ////                ActivityId = 6,
        ////                UserId = TestUser.Identifier,
        ////            })
        ////            .WithData(new Vote
        ////            {
        ////                Id = 1,
        ////                ActivityId = 6,
        ////                UserId = TestUser.Identifier,
        ////                Value = 5,
        ////            }))
        ////        .Calling(a => a.Details(4, "information"))
        ////        .ShouldReturn()
        ////        .View(v => v.WithModelOfType<SingleActivityViewModel>());
        ////}

        [Theory]
        [InlineData(10)]
        [InlineData(11)]
        public void GetJoinShouldRedirect(int categoryId)
        {
            MyController<ActivitiesController>
                .Instance(x => x.WithUser().WithData(new UserActivity
                {
                    ActivityId = 10,
                    UserId = TestUser.Identifier,
                }))
                .Calling(a => a.Join(categoryId, With.Value("information")))
                .ShouldHave()
                .Data(d => d.WithSet<UserActivity>(ua => ua.Any(x =>
                    x.ActivityId == 10 &&
                    x.UserId == TestUser.Identifier)))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Details");
        }

        [Fact]
        public void GetDisJoinShouldRedirect()
        {
            MyController<ActivitiesController>
                .Instance(x => x.WithUser().WithData(new UserActivity
                {
                    ActivityId = 10,
                    UserId = TestUser.Identifier,
                }))
                .Calling(a => a.DisJoin(10, With.Value("information")))
                .ShouldReturn()
                .RedirectToAction("Details", new { id = 10, information = "information" });
        }

        [Fact]
        public void GetEditShouldReturnViewWithCorrectModel()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithData(GetSingleCategory())
                    .WithData(GetSingleActivity()))
                .Calling(a => a.Edit(2))
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityEditViewModel>()
                    .Passing(x =>
                        x.CategoriesItems.Count() == 1 &&
                        x.Name == "TestName" &&
                        x.CategoryId == 3));
        }

        [Theory]
        [InlineData(10, "EditedName", "2020, 12, 12", "EditedLocation")]
        public void PostEditWithValidModelStateAndHaveTempDataShouldUpdateActivityByIdAndRedirect(int categoryId, string name, DateTime startTime, string location)
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser()
                    .WithData(GetCategories())
                    .WithData(GetSingleActivity()))
                .Calling(a => a.Edit(2, new ActivityEditViewModel
                {
                    CategoryId = categoryId,
                    Name = name,
                    StartTime = startTime,
                    Location = location,
                }))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .TempData(td => td.ContainingEntryWithKey("UpdatedActivity"))
                .Data(x => x.WithSet<Activity>(d => d.Any(a =>
                    a.Name == name &&
                    a.CategoryId == categoryId &&
                    a.StartTime == startTime &&
                    a.Location == location)))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Details");
        }

        [Fact]
        public void PostEditShouldReturnViewWithCorrectModelWithInvalidModelState()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser())
                .Calling(a => a.Edit(2, new ActivityEditViewModel
                {
                    Name = string.Empty,
                }))
                .ShouldHave()
                .InvalidModelState()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityEditViewModel>()
                    .Passing(x => x.Name == string.Empty));
        }

        [Fact]
        public void GetDeleteShouldDeleteActivityByIdAndRedirect()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithData(GetSingleActivity()))
                .Calling(x => x.Delete(2))
                .ShouldReturn()
                .RedirectToAction("Index");
        }
    }
}
