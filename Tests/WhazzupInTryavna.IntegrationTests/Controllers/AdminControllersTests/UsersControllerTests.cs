

using System.Linq;

namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Users;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.UserData;
    using static WhazzupInTryavna.IntegrationTests.Data.RolesData;

    public class UsersControllerTests
    {
        [Fact]
        public void GetAll()
        {
            MyController<UsersController>
                .Instance(x => x.
                    WithData(GetUsers())
                    .WithData(GetRoles()))
                .Calling(x => x.All())
                .ShouldReturn()
                .View(v => v.WithModelOfType<UsersListingViewModel>()
                    .Passing(x => x.Users.Count() == 1));
        }

        [Fact]
        public void GetBan()
        {
            MyController<UsersController>
                .Instance(x => x.WithData(GetUsers()))
                .Calling(x => x.Ban("TestAppUser"))
                .ShouldReturn()
                .RedirectToAction("All");
        }
    }
}
