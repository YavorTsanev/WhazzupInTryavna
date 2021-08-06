namespace WhazzupInTryavna.Data.Models.Activities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Data.Common.Models;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(CategoryConst.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();
    }
}
