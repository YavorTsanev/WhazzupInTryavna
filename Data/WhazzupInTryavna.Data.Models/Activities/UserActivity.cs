namespace WhazzupInTryavna.Data.Models.Activities
{
    using WhazzupInTryavna.Data.Common.Models;

    public class UserActivity : BaseDeletableModel<int>
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
    }
}
