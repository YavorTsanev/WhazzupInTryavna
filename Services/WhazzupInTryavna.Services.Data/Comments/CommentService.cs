using System.Threading.Tasks;
using WhazzupInTryavna.Data.Common.Repositories;
using WhazzupInTryavna.Data.Models.Activities;
using WhazzupInTryavna.Web.ViewModels.Comments;

namespace WhazzupInTryavna.Services.Data.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CommentService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentRepository)
        {
            this.commentRepository = commentRepository;
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
    }
}
