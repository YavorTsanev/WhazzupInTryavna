namespace WhazzupInTryavna.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BaseAuthorizeController : Controller
    {
    }
}
