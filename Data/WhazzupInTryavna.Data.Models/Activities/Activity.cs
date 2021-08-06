namespace WhazzupInTryavna.Data.Models.Activities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Data.Common.Models;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class Activity : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(ActivityConst.NameMaxLength)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(ActivityConst.LocationMaxLength)]
        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();

        public virtual ICollection<UserActivity> UserActivities { get; set; } = new HashSet<UserActivity>();

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}
