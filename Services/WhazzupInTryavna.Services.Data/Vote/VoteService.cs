namespace WhazzupInTryavna.Services.Data.Vote
{
    using System.Linq;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;

    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> votesRepository;

        public VoteService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public async Task SetVoteAsync(int activityId, string userId, byte value)
        {
            var vote = this.votesRepository.All().FirstOrDefault(x => x.ActivityId == activityId && x.UserId == userId);

            if (vote == null)
            {
                vote = new Vote
                {
                    ActivityId = activityId,
                    UserId = userId,
                };
                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;

            await this.votesRepository.SaveChangesAsync();
        }

        public double GetAvgVote(int activityId)
        {
            return this.votesRepository.All().Where(x => x.ActivityId == activityId).Average(x => x.Value);
        }
    }
}
