namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using System.Linq;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Users;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.RolesData;
    using static WhazzupInTryavna.IntegrationTests.Data.UserData;

    public class UsersControllerTests
    {
        [Fact]
        public void GetAllShouldReturnViewWithAllUsersWithoutAdminUser()
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
        public void GetBanShouldDeleteAndSignOutUserByIdAndRedirect()
        {
            MyController<UsersController>
                .Instance(x => x.WithData(GetUsers()))
                .Calling(x => x.Ban("TestAppUser"))
                .ShouldReturn()
                .RedirectToAction("All");
        }

        [Fact]
        public void GetUnBanShouldUnDeleteUserByIdAndRedirect()
        {
            MyController<UsersController>
                .Instance(x => x.WithData(GetUsers()))
                .Calling(x => x.UnBan("TestAppUser"))
                .ShouldReturn()
                .RedirectToAction("All");
        }
    }
}
