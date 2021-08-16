namespace WhazzupInTryavna.IntegrationTests.Routing
{
    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Votes;
    using Xunit;

    public class VotesControllerTests
    {
        [Fact]
        public void PostRouteShouldBeMapped()
        {
            MyRouting
                .Configuration()
                .ShouldMap(x => x
                    .WithPath("/api/Votes")
                    .WithMethod(HttpMethod.Post))
                .To<VotesController>(c => c.Post(With.Any<PostVoteViewModel>()));
        }
    }
}
