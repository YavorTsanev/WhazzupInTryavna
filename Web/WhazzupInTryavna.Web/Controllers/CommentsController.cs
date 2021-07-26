using Microsoft.AspNetCore.Authorization;
using WhazzupInTryavna.Web.ViewModels.Comments;

namespace WhazzupInTryavna.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize]
    public class CommentsController : BaseController
    {
        [HttpPost]
        public IActionResult Add(CommentAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Details", "Activities", new { id = model.ActivityId }, "message");
            }

            return this.RedirectToAction("Details", "Activities", new { id = model.ActivityId }, "message");
        }
    }
}
