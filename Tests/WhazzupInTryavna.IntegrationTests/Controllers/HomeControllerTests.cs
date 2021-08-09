



namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using static Data.HomeData;
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;
    using WhazzupInTryavna.Web.ViewModels.Home;

    public class HomeControllerTests
    {
        [Fact]

        public void IndexShouldReturnCorrectViewWithModel()
        {
            MyController<HomeController>
                .Instance()
                .Calling(c => c.Index())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<HomeViewModel>());
        }
    }
}
