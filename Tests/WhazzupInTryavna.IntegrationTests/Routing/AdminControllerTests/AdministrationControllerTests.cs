namespace WhazzupInTryavna.IntegrationTests.Routing.AdminControllerTests
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using Xunit;

    public class AdministrationControllerTests
    {
        [Fact]
        public void GetIndexRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Administration")
                .To<AdministrationController>(c => c.Index());
        }
    }
}
