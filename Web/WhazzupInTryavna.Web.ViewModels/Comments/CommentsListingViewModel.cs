namespace WhazzupInTryavna.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    public class CommentsListingViewModel
    {
        public IEnumerable<CommentInListViewModel> Comments { get; set; }
    }
}
