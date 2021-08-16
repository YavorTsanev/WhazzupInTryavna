namespace WhazzupInTryavna.Web.Areas.Administration.Controllers
{
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CommentsControllerTests
    {
        [Fact]
        public void GetAllRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Comments/All")
                .To<CommentsController>(c => c.All(With.Any<int>()));
        }

        [Fact]
        public void GetDeleteRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Comments/Delete")
                .To<CommentsController>(c => c.Delete(With.Any<int>(), With.Any<int>()));
        }
    }
}
