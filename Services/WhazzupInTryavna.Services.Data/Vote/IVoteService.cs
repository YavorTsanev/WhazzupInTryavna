namespace WhazzupInTryavna.Services.Data.Vote
{
    using System.Threading.Tasks;

    public interface IVoteService
    {
        Task SetVoteAsync(int activityId, string userId, byte value);

        double GetAvgVote(int activityId);
    }
}
