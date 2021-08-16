namespace WhazzupInTryavna.IntegrationTests.Routing.AdminControllerTests
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Areas.Administration.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Administration.News;
    using Xunit;

    public class NewsControllerTests
    {
        [Fact]
        public void GetAllRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/News/All")
                .To<NewsController>(c => c.All());
        }

        [Fact]
        public void GetEditRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/News/Edit")
                .To<NewsController>(c => c.Edit(With.Any<int>()));
        }

        [Fact]
        public void PostEditRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/Administration/News/Edit")
                    .WithMethod(HttpMethod.Post))
                .To<NewsController>(c => c.Edit(With.Any<int>(), With.Any<NewsAdminEditViewModel>()));
        }

        [Fact]
        public void GetDeleteRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/News/Delete")
                .To<NewsController>(c => c.Delete(With.Any<int>()));
        }
    }
}
