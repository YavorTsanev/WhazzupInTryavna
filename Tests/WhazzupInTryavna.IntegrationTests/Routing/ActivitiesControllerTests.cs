namespace WhazzupInTryavna.IntegrationTests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Activities;
    using Xunit;

    public class ActivitiesControllerTests
    {
        [Fact]
        public void GetIndexRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Activities")
                .To<ActivitiesController>(c => c.Index(With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>(), With.Any<string>()));
        }

        [Fact]
        public void GetAddRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Activities/Add")
                .To<ActivitiesController>(c => c.Add());
        }

        [Fact]
        public void PostAddRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/Activities/Add")
                    .WithMethod(HttpMethod.Post))
                .To<ActivitiesController>(c => c.Add(With.Any<ActivityFormModel>()));
        }

        [Fact]
        public void GetDetailsRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Activities/Details")
                .To<ActivitiesController>(c => c.Details(With.Any<int>(), With.Any<string>()));
        }

        [Fact]
        public void GetJoinRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Activities/Join")
                .To<ActivitiesController>(c => c.Join(With.Any<int>(), With.Any<string>()));
        }

        [Fact]
        public void GetDisJoinRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Activities/DisJoin")
                .To<ActivitiesController>(c => c.DisJoin(With.Any<int>(), With.Any<string>()));
        }

        [Fact]
        public void GetEditRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Activities/Edit")
                .To<ActivitiesController>(c => c.Edit(With.Any<int>()));
        }

        [Fact]
        public void PostEditRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/Activities/Edit")
                    .WithMethod(HttpMethod.Post))
                .To<ActivitiesController>(c => c.Edit(With.Any<int>(), With.Any<ActivityEditViewModel>()));
        }

        [Fact]
        public void GetDeleteRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap("/Activities/Delete")
                .To<ActivitiesController>(c => c.Delete(With.Any<int>()));
        }
    }
}
