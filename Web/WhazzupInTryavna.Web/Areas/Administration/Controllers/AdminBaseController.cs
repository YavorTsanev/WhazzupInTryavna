namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static WhazzupInTryavna.Common.GlobalConstants;

    [Authorize(Roles = AdminConst.RoleName)]
    [Area(AdminConst.AreaName)]
    public class AdminBaseController : Controller
    {
    }
}
