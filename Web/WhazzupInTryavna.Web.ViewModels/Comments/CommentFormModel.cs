namespace WhazzupInTryavna.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Web.ViewModels.Activities;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class CommentFormModel : IActivityModel
    {
        [Required]
        [MinLength(CommentConst.ContentMinLength)]
        [MaxLength(CommentConst.ContentMaxLength)]
        public string Content { get; set; }

        public int ActivityId { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }
    }
}
