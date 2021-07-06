﻿namespace WhazzupInTryavna.Data.Models.Activities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using WhazzupInTryavna.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"(?:([^:\/?#]+):)?(?:\/\/([^\/?#]*))?([^?#]*\.(?:jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?", ErrorMessage = "Only Image files allowed.")]
        public string Image { get; set; }

        public virtual ICollection<Activity> Activities { get; set; } = new HashSet<Activity>();
    }
}
