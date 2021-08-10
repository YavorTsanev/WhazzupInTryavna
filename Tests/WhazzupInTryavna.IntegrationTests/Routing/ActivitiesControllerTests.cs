namespace WhazzupInTryavna.IntegrationTests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;

    public class ActivitiesControllerTests
    {
        [Fact]
        public void IndexRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Activities/Index")
                .To<ActivitiesController>(c => c.Index(With.Any<string>(),With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>()));
        }
    }
}
