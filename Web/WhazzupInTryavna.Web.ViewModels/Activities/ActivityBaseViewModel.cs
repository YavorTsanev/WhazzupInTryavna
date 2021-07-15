namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public abstract class ActivityBaseViewModel
    {
        [Required]
        [MinLength(ActivityNameMinLength)]
        [MaxLength(ActivityNameMaxLength)]
        public string Name { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Description   (optional)")]
        public string Description { get; set; }

        [Required]
        [MinLength(ActivityLocationMinLength)]
        [MaxLength(ActivityLocationMaxLength)]
        public string Location { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
