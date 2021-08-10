namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;

    public class BaseAuthorizeControllerTests
    {
        [Fact]
        public void ActivitiesControllerShouldHaveRestrictingForAuthorizedRequests()
        {
            MyController<BaseAuthorizeController>
                .Instance()
                .ShouldHave()
                .Attributes(a => a.RestrictingForAuthorizedRequests());
        }
    }
}
