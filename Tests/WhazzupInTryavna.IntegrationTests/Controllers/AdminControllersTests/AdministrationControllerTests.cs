namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using Xunit;

    public class AdministrationControllerTests
    {
        [Fact]
        public void GetIndexShouldReturnView()
        {
            MyController<AdministrationController>
                .Instance()
                .Calling(x => x.Index())
                .ShouldReturn()
                .View();
        }
    }
}
