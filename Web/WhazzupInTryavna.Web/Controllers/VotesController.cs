namespace WhazzupInTryavna.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Services.Data.Vote;
    using WhazzupInTryavna.Web.ViewModels.Votes;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService voteService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVoteService voteService, UserManager<ApplicationUser> userManager)
        {
            this.voteService = voteService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<PostResponseViewModel>> Post(PostVoteViewModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.voteService.SetVoteAsync(input.ActivityId, userId, input.Value);

            var avgVote = this.voteService.GetAvgVote(input.ActivityId);
            return new PostResponseViewModel { AvgVote = avgVote };
        }
    }
}
