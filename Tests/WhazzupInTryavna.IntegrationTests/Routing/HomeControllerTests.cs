namespace WhazzupInTryavna.IntegrationTests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void GetIndexRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/")
                .To<HomeController>(c => c.Index());
        }

        [Fact]
        public void GetPrivacyRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Home/Privacy")
                .To<HomeController>(c => c.Privacy());
        }

        [Fact]
        public void GetErrorRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Home/Error")
                .To<HomeController>(c => c.Error());
        }
    }
}
