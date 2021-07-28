namespace WhazzupInTryavna.Services.Data.Comments
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using WhazzupInTryavna.Data.Common.Repositories;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;
    using WhazzupInTryavna.Web.ViewModels.Comments;

    public class CommentService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;
        private readonly IDeletableEntityRepository<Activity> activityRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentRepository, IDeletableEntityRepository<Activity> activityRepository)
        {
            this.commentRepository = commentRepository;
            this.activityRepository = activityRepository;
        }

        public async Task AddAsync(string userId, CommentAddViewModel model)
        {
            var comment = new Comment
            {
                ActivityId = model.ActivityId,
                Content = model.Content,
                UserId = userId,
            };

            await this.commentRepository.AddAsync(comment);
            await this.commentRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.commentRepository.All().OrderByDescending(x => x.CreatedOn).To<T>();
        }

        public IEnumerable<T> GetAllByActivityId<T>(int activityId)
        {
            return this.commentRepository.All().Where(x => x.ActivityId == activityId).To<T>();
        }

        public string GetActivityName(int activityId)
        {
            return this.activityRepository.All().Where(x => x.Id == activityId).Select(x => x.Name)
                .FirstOrDefault();
        }

        public async Task DeleteAsync(int commentId)
        {
            var commentToDelete = this.commentRepository.All().FirstOrDefault(x => x.Id == commentId);

            this.commentRepository.Delete(commentToDelete);
            await this.commentRepository.SaveChangesAsync();
        }
    }
}
