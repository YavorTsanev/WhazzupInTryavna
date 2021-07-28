namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Services.Data.Users;
    using WhazzupInTryavna.Web.ViewModels.Administration.Users;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class UsersController : AdminBaseController
    {
        private readonly IUsersService usersService;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UsersController(IUsersService usersService, RoleManager<ApplicationRole> roleManager)
        {
            this.usersService = usersService;
            this.roleManager = roleManager;
        }

        public IActionResult All()
        {
            var roleId = this.GetAdminRoleId();

            var model = new UsersListingViewModel
            {
                Users = this.usersService.GetAll<UserInListViewModel>(roleId),
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

        private string GetAdminRoleId()
        {
            return this.roleManager.Roles.Where(x => x.Name == AdministratorRoleName).Select(x => x.Id)
                .FirstOrDefault();
        }
    }
}
