namespace WhazzupInTryavna.Web.ViewModels.Administration.Comments
{
    using System.Collections.Generic;

    public class CommentsAdminListingViewModel
    {
        public string ActivityName { get; set; }

        public int ActivityId { get; set; }

        public IEnumerable<CommentAdminInListViewModel> Comments { get; set; }
    }
}
