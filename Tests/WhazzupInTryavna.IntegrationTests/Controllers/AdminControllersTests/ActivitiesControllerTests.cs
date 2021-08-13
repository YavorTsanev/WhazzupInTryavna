using MyTested.AspNetCore.Mvc;
using WhazzupInTryavna.Data.Models.Activities;
using WhazzupInTryavna.Web.Areas.Administration.Controllers;
using WhazzupInTryavna.Web.ViewModels.Activities;
using WhazzupInTryavna.Web.ViewModels.Administration.Activities;
using Xunit;

namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static WhazzupInTryavna.IntegrationTests.Data.ActivityData;
    using static WhazzupInTryavna.IntegrationTests.Data.CategoryData;

    public class ActivitiesControllerTests
    {
        [Fact]
        public void GetAllShouldReturnViewWithModel()
        {
            MyController<ActivitiesController>
                .Instance()
                .Calling(x => x.All())
                .ShouldReturn()
                .View(x => x.WithModelOfType<ActivitiesAdminListingViewModel>());
        }

        [Fact]
        public void GetEditShouldReturnViewWithModel()
        {
            MyController<ActivitiesController>
                .Instance(x => x.WithUser()
                    .WithData(new Activity
                    {
                        Id = 5,
                        Name = "TestName",
                        Location = "TestLocation",
                        CategoryId = 3,
                        StartTime = DateTime.Now,
                    })
                    .WithData(GetSingleActivity()))
                .Calling(a => a.Edit(5))
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityAdminEditViewModel>());
        }

        [Theory]
        [InlineData(3, "TestName", "2020, 12, 12", "TestLocation")]
        public void PostEditShouldRedirectAndHaveTempDataWithValidModelState(int categoryId, string name, DateTime startTime, string location)
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser()
                    .WithData(GetCategory()).WithData(GetSingleActivity()))
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
        public void PostEditShouldReturnViewWithModelWithInvalidModelState()
        {
            MyController<ActivitiesController>
                .Instance(x => x
                    .WithUser())
                .Calling(a => a.Edit(2, new ActivityAdminEditViewModel()))
                .ShouldHave()
                .InvalidModelState()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .AndAlso()
                .ShouldReturn()
                .View(v => v.WithModelOfType<ActivityAdminEditViewModel>());
        }

        [Fact]
        public void GetDeleteShouldRedirect()
        {
            MyController<ActivitiesController>
                .Instance(x => x.WithUser()
                    .WithData(GetSingleActivity()))
                .Calling(x => x.Delete(2))
                .ShouldReturn()
                .RedirectToAction("All");
        }
    }
}
