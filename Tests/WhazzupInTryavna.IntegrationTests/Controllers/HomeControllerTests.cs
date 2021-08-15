using WhazzupInTryavna.Web.ViewModels;

namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Home;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.ActivityData;
    using static WhazzupInTryavna.IntegrationTests.Data.NewsData;
    using static WhazzupInTryavna.IntegrationTests.Data.UserData;

    public class HomeControllerTests
    {
        [Fact]
        public void HomeControllerShouldHaveAttributeAllowingAnonymousRequests()
        {
            MyController<HomeController>
                .Instance()
                .ShouldHave()
                .Attributes(a => a.AllowingAnonymousRequests());
        }

        [Fact]
        public void IndexShouldReturnViewWithCorrectModel()
        {
            MyController<HomeController>
                .Instance(x => x
                    .WithData(GetNews())
                    .WithData(GetUsers())
                    .WithData(GetActivities()))
                .Calling(c => c.Index())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<HomeViewModel>()
                    .Passing(x => x.ActivitiesCount == 2 &&
                                  x.NewsCount == 1 &&
                                  x.UsersCount == 2));
        }

        [Fact]
        public void PrivacyShouldReturnView()
        {
            MyController<HomeController>
                .Instance()
                .Calling(c => c.Privacy())
                .ShouldReturn()
                .View();
        }

        [Fact]
        public void ErrorShouldReturnViewWithModel()
        {
            MyController<HomeController>
                .Instance()
                .Calling(c => c.Error())
                .ShouldReturn()
                .View(v => v.WithModelOfType<ErrorViewModel>());
        }
    }
}
