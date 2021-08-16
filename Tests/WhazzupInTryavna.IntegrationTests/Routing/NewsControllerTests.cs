namespace WhazzupInTryavna.IntegrationTests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;

    public class NewsControllerTests
    {
        [Fact]
        public void GetIndexRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/News/Index")
                .To<NewsController>(c => c.Index());
        }

        [Fact]
        public void GetDetailsRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/News/Details")
                .To<NewsController>(c => c.Details(With.Any<int>(), With.Any<string>()));
        }
    }
}
