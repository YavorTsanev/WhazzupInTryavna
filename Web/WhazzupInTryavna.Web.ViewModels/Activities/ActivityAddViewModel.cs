using System.Collections.Generic;
using System.ComponentModel;

namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static WhazzupInTryavna.Common.GlobalConstants;

    public class ActivityAddViewModel
    {
        [Required]
        [MinLength(ActivityNameMinLength)]
        [MaxLength(ActivityNameMaxLength)]
        public string Name { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public string Description { get; set; }

        [Required]
        [MinLength(ActivityLocationMinLength)]
        [MaxLength(ActivityLocationMaxLength)]
        public string Location { get; set; }

        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        public string AddedByUserId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
