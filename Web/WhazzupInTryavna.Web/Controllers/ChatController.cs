namespace WhazzupInTryavna.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : Controller
    {
        public IActionResult Chat()
        {
            return this.View();
        }
    }
}
