namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Services.Data.Vote;
    using WhazzupInTryavna.Web.Infrastructure;
    using WhazzupInTryavna.Web.ViewModels.Votes;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService voteService;

        public VotesController(IVoteService voteService)
        {
            this.voteService = voteService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostResponseViewModel>> Post(PostVoteViewModel input)
        {
            var userId = this.User.GetId();
            await this.voteService.SetVoteAsync(input.ActivityId, userId, input.Value);

            var avgVote = this.voteService.GetAvgVote(input.ActivityId);
            return new PostResponseViewModel { AvgVote = avgVote };
        }
    }
}
