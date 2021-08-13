namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using Xunit;

    public class BaseAuthorizeControllerTests
    {
        [Fact]
        public void BaseAuthorizeControllerShouldHaveAuthorizeAttribute()
        {
            MyController<BaseAuthorizeController>
                .ShouldHave()
                .Attributes(x => x.RestrictingForAuthorizedRequests());
        }
    }
}
