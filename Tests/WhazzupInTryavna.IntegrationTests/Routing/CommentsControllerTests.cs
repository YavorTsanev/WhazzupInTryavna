namespace WhazzupInTryavna.IntegrationTests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Comments;
    using Xunit;

    public class CommentsControllerTests
    {
        [Fact]
        public void PostAddRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/Comments/Add")
                    .WithMethod(HttpMethod.Post))
                .To<CommentsController>(c => c.Add(With.Any<CommentFormModel>(), With.Any<string>()));
        }
    }
}
