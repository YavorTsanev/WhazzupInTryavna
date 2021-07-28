namespace WhazzupInTryavna.Web.ViewModels.Administration.Comments
{
    using System;

    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class CommentAdminInListViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string ActivityName { get; set; }

        public string UserUserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
