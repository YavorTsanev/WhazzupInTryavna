using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WhazzupInTryavna.Data.Common.Models;

namespace WhazzupInTryavna.Data.Models.Activities
{
    public class Category : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();
    }
}
