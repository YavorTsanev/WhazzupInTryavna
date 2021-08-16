namespace WhazzupInTryavna.IntegrationTests.Controllers
{
    using System.Linq;

    using MyTested.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Web.Controllers;
    using WhazzupInTryavna.Web.ViewModels.Votes;
    using Xunit;

    using static WhazzupInTryavna.IntegrationTests.Data.ActivityData;

    using HttpMethod = System.Net.Http.HttpMethod;

    public class VotesControllerTests
    {
        [Fact]
        public void PostShouldSetVoteAndReturnPostResponseViewModel()
        {
            MyController<VotesController>
                .Instance(x => x
                    .WithData(GetSingleActivity())
                    .WithUser())
                .Calling(x => x.Post(new PostVoteViewModel
                {
                    ActivityId = 2,
                    Value = 5,
                }))
                .ShouldHave()
                .ActionAttributes(x => x.RestrictingForHttpMethod(HttpMethod.Post))
                .ActionAttributes(x => x.RestrictingForAuthorizedRequests())
                .Data(x => x.WithSet<Vote>(d => d.Any(v =>
                    v.Value == 5 &&
                    v.ActivityId == 2 &&
                    v.UserId == TestUser.Identifier)))
                .AndAlso()
                .ShouldReturn()
                .Object(x => x.WithModelOfType<PostResponseViewModel>());
        }
    }
}
