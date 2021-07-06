namespace WhazzupInTryavna.Data.Models.Activities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using WhazzupInTryavna.Data.Common.Models;

    public class Activity : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();

        public virtual ICollection<UserActivity> UserActivities { get; set; } = new HashSet<UserActivity>();
    }
}
