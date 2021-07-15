namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ActivityListingViewModel
    {
        [Display(Name = "Time to start")]
        public string TimeToStart { get; set; }

        public string Participants { get; set; }

        public string Category { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ActivityInListViewModel> Activities { get; set; }
    }
}
