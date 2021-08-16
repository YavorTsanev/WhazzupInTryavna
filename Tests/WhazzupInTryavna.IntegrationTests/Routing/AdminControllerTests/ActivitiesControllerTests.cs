namespace WhazzupInTryavna.IntegrationTests.Routing.AdminControllerTests
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.ViewModels.Administration.Activities;
    using Xunit;

    using ActivitiesController = WhazzupInTryavna.Web.Areas.Administration.Controllers.ActivitiesController;

    public class ActivitiesControllerTests
    {
        [Fact]
        public void GetAllRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Activities/All")
                .To<ActivitiesController>(c => c.All());
        }

        [Fact]
        public void GetEditRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Activities/Edit")
                .To<ActivitiesController>(c => c.Edit(With.Any<int>()));
        }

        [Fact]
        public void PostEditRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/Administration/Activities/Edit")
                    .WithMethod(HttpMethod.Post))
                .To<ActivitiesController>(c => c.Edit(With.Any<int>(), With.Any<ActivityAdminEditViewModel>()));
        }

        [Fact]
        public void GetDeleteRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Administration/Activities/Delete")
                .To<ActivitiesController>(c => c.Delete(With.Any<int>()));
        }
    }
}
