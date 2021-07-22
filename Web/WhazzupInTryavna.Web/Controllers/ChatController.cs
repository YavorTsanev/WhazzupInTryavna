namespace WhazzupInTryavna.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ChatController : BaseController
    {
        public IActionResult Chat()
        {
            return this.View();
        }
    }
}
