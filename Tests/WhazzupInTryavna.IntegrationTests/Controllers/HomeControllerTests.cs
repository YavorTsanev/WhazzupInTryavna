using WhazzupInTryavna.Web.ViewModels;

namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Home;
    using Xunit;

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
        public void IndexShouldReturnViewWithModel()
        {
            MyController<HomeController>
                .Instance()
                .Calling(c => c.Index())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<HomeViewModel>());
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
