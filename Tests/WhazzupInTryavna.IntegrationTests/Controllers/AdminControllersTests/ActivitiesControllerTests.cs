namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using System;
    using System.Linq;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Activities;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.ActivityData;
    using static WhazzupInTryavna.IntegrationTests.Data.CategoryData;

    public class ActivitiesControllerTests
    {
        [Fact]
        public void GetAllShouldReturnViewWithCorrectModel()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithData(GetActivities())
                    .WithUser()
                    .WithData(GetCategories()))
                .Calling(x => x.All())
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivitiesAdminListingViewModel>()
                    .Passing(x => x.Activities.Count() == 2));
        }

        [Fact]
        public void GetEditShouldReturnViewWithCorrectModel()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser()
                    .WithData(GetSingleActivity())
                    .WithData(GetSingleCategory()))
                .Calling(a => a.Edit(2))
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityAdminEditViewModel>()
                    .Passing(x => x.Name == "TestName" &&
                                  x.Location == "TestLocation"));
        }

        [Theory]
        [InlineData(3, "TestName", "2020, 12, 12", "TestLocation")]
        public void PostEditShouldRedirectAndHaveTempDataWithValidModelState(int categoryId, string name, DateTime startTime, string location)
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser()
                    .WithData(GetSingleCategory())
                    .WithData(GetSingleActivity()))
                .Calling(a => a.Edit(2, new ActivityAdminEditViewModel()
                {
                    CategoryId = categoryId,
                    Name = name,
                    StartTime = startTime,
                    Location = location,
                }))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .TempData(td => td.ContainingEntryWithKey("AdminUpdatedActivity"))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("All");
        }

        [Fact]
        public void PostEditShouldReturnViewWithCorrectModelWithInvalidModelState()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser())
                .Calling(a => a.Edit(2, new ActivityAdminEditViewModel
                {
                    Name = string.Empty,
                }))
                .ShouldHave()
                .InvalidModelState()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityAdminEditViewModel>()
                    .Passing(x => x.Name == string.Empty));
        }

        [Fact]
        public void GetDeleteShouldRedirect()
        {
            MyController<ActivitiesController>
                .Instance(x => x.
                    WithUser()
                    .WithData(GetSingleActivity()))
                .Calling(x => x.Delete(2))
                .ShouldReturn()
                .RedirectToAction("All");
        }
    }
}
