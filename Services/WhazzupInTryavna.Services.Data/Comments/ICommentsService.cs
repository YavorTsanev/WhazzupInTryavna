﻿using System.Collections.Generic;

namespace WhazzupInTryavna.Services.Data.Comments
{
    using System.Threading.Tasks;

    using WhazzupInTryavna.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        Task AddAsync(string userId, CommentAddViewModel model);

        IEnumerable<T> GetAll<T>();
    }
}
