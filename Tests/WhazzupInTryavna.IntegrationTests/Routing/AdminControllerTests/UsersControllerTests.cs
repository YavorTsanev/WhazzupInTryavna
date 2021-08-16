namespace WhazzupInTryavna.IntegrationTests.Routing.AdminControllerTests
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using Xunit;

    public class UsersControllerTests
    {
        [Fact]
        public void GetAllRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Users/All")
                .To<UsersController>(c => c.All());
        }

        [Fact]
        public void GetBanRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Users/Ban")
                .To<UsersController>(c => c.Ban(With.Any<string>()));
        }

        [Fact]
        public void GetUnBanRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Users/UnBan")
                .To<UsersController>(c => c.UnBan(With.Any<string>()));
        }
    }
}
