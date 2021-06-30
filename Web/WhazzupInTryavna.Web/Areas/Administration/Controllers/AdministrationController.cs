namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using WhazzupInTryavna.Common;
    using WhazzupInTryavna.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
