using MyTested.AspNetCore.Mvc;
using WhazzupInTryavna.Web.Areas.Administration.Controllers;
using Xunit;

namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllers
{
    public class AdminBaseControllerTests
    {
        [Fact]
        public void AdminBaseControllerShouldHaveAuthorizeAttribute()
        {
            MyController<AdminBaseController>
                .ShouldHave()
                .Attributes(x => x.RestrictingForAuthorizedRequests());
        }
    }
}
