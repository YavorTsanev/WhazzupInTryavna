namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ActivityListingViewModel
    {
        [Display(Name = "SEARCH BY NAME")]
        public string SearchTerm { get; set; }

        [Display(Name = "SORT BY CATEGORY")]
        public string Category { get; set; }

        [Display(Name = "SORT ACTIVITIES")]
        public string Activity { get; set; }

        [Display(Name = "COUNT OF JOINS")]
        public string CountOfJoins { get; set; }

        [Display(Name = "SORT BY START TIME")]
        public string TimeToStart { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ActivityInListViewModel> Activities { get; set; }
    }
}
