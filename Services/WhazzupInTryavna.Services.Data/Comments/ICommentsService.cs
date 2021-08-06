namespace WhazzupInTryavna.Services.Data.Comments
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        Task AddAsync(string userId, CommentFormModel model);

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllByActivityId<T>(int activityId);

        string GetActivityName(int activityId);

        Task DeleteAsync(int commentId);
    }
}
