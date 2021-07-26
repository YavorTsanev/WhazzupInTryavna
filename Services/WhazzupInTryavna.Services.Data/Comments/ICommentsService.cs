using System.Threading.Tasks;
using WhazzupInTryavna.Web.ViewModels.Comments;

namespace WhazzupInTryavna.Services.Data.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommentsService
    {
        Task AddAsync(string userId, CommentAddViewModel model);
    }
}
