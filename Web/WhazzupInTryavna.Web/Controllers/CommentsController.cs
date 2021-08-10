namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Services.Data.Comments;
    using WhazzupInTryavna.Web.Infrastructure;
    using WhazzupInTryavna.Web.ViewModels.Comments;

    public class CommentsController : BaseAuthorizeController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentFormModel model, string information)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Details", "Activities", new { id = model.ActivityId, information });
            }

            await this.commentsService.AddAsync(this.User.GetId(), model);

            return this.RedirectToAction("Details", "Activities", new { id = model.ActivityId, information });
        }
    }
}
