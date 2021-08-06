namespace WhazzupInTryavna.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class CommentFormModel
    {
        [Required]
        [MinLength(CommentContentMinLength)]
        [MaxLength(CommentContentMaxLength)]
        public string Content { get; set; }

        public int ActivityId { get; set; }

        public string UserId { get; set; }
    }
}
