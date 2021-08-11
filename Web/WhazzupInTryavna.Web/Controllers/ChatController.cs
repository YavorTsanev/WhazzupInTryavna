namespace WhazzupInTryavna.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ChatController : BaseAuthorizeController
    {
        public IActionResult Chat()
        {
            return this.View();
        }
    }
}
