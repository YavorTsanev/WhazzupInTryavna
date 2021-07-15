namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System.Collections.Generic;

    public class ActivitiesListViewModel
    {
        public string Participants { get; set; }

        public string Category { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<ActivityInListViewModel> Activities { get; set; }
    }
}
