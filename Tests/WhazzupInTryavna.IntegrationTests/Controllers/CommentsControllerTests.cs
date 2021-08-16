namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using System.Linq;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Comments;
    using Xunit;

    public class CommentsControllerTests
    {
        [Fact]
        public void PostAddShouldAddNewCommentForActivityAndRedirectWithValidModelState()
        {
            MyController<CommentsController>
                .Instance(x => x.WithUser())
                .Calling(x => x.Add(
                    new CommentFormModel
                    {
                        Name = "TestName",
                        Location = "TestLocation",
                        ActivityId = 2,
                        UserId = TestUser.Identifier,
                        Content = "TestContent",
                    },
                    "information"))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .ValidModelState()
                .Data(x => x.WithSet<Comment>(d => d.Any(c =>
                    c.Content == "TestContent" &&
                    c.ActivityId == 2 &&
                    c.UserId == TestUser.Identifier)))
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Details", "Activities", new { id = 2, information = "information" });
        }

        [Fact]
        public void PostAddShouldRedirectWithInvalidModelState()
        {
            MyController<CommentsController>
                .Instance(x => x.WithUser())
                .Calling(x => x.Add(
                    new CommentFormModel(), "information"))
                .ShouldHave()
                .ActionAttributes(a => a.RestrictingForHttpMethod(System.Net.Http.HttpMethod.Post))
                .InvalidModelState()
                .AndAlso()
                .ShouldReturn()
                .RedirectToAction("Details", "Activities", new { id = 0, information = "information" });
        }
    }
}
