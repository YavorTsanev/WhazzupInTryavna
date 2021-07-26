namespace WhazzupInTryavna.Web.ViewModels.Administration.Activities
{
    using WhazzupInTryavna.Web.ViewModels.Activities;

    public class ActivityAdminInListViewModel : ActivityInListViewModel
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string AddedByUserUserName { get; set; }

        public int UserActivitiesCount { get; set; }
    }
}
