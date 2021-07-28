namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Services.Data.Comments;
    using WhazzupInTryavna.Web.ViewModels.Administration.Comments;

    public class CommentsController : AdminBaseController
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public IActionResult All(int id)
        {
            var model = new CommentsAdminListingViewModel
            {
                ActivityId = id,
                Comments = this.commentsService.GetAllByActivityId<CommentAdminInListViewModel>(id),
                ActivityName = this.commentsService.GetActivityName(id),
            };

            return this.View(model);
        }

        public async Task<IActionResult> Delete(int id, int activityId)
        {
            await this.commentsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All), new { id = activityId });
        }
    }
}
