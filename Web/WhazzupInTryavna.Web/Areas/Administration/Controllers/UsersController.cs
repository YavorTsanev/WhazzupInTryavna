namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Services.Data.Users;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Users;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult All()
        {
            var model = new UsersListingViewModel
            {
                Users = this.usersService.GetAll<UserInListViewModel>(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> Ban(string id)
        {
            await this.usersService.BanAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }

        public async Task<IActionResult> UnBan(string id)
        {
            await this.usersService.UnBanAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
