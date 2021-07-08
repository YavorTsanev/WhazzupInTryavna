namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ActivitiesListViewModel
    {
        public IEnumerable<ActivityInListViewModel> Activities { get; set; }
    }
}
