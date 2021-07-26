namespace WhazzupInTryavna.Web.ViewModels.Comments
{
    using System;

    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class CommentInListViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
