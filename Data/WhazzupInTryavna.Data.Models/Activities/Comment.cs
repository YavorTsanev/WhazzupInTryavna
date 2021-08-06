namespace WhazzupInTryavna.Data.Models.Activities
{
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Data.Common.Models;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CommentConst.ContentMaxLength)]
        public string Content { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
