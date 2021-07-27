namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Services.Data.Comments;
    using WhazzupInTryavna.Web.Infrastructure;
    using WhazzupInTryavna.Web.ViewModels.Comments;

    [Authorize]
    public class CommentsController : BaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentAddViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Details", "Activities", new { id = model.ActivityId });
            }

            await this.commentsService.AddAsync(this.User.GetId(), model);

            return this.RedirectToAction("Details", "Activities", new { id = model.ActivityId });
        }
    }
}
