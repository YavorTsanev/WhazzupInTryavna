namespace WhazzupInTryavna.IntegrationTests.Controllers.AdminControllersTests
{
    using System.Linq;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.Comments;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.ActivityData;
    using static WhazzupInTryavna.IntegrationTests.Data.CommentsData;

    public class CommentsControllerTests
    {
        [Fact]
        public void GetAllShouldReturnViewWithCorrectModel()
        {
            MyController<CommentsController>
                .Instance(x => x
                    .WithData(GetSingleActivity())
                    .WithUser())
                .Calling(x => x.All(2))
                .ShouldReturn()
                .View(v => v.WithModelOfType<CommentsAdminListingViewModel>()
                    .Passing(x => x.ActivityId == 2 && x.ActivityName == "TestName" && x.Comments.Any(c => c.Content == "TestContent")));
        }

        [Fact]
        public void GetDeleteShouldDeleteCommentByIdAdnRedirectToActivityById()
        {
            MyController<CommentsController>
                .Instance(x => x.WithData(GetComment()))
                .Calling(x => x.Delete(5, 2))
                .ShouldReturn()
                .RedirectToAction("All", new { id = 2 });
        }
    }
}
