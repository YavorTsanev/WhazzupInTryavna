namespace WhazzupInTryavna.Web.ViewModels.Administration.Activities
{
    using System;

    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class ActivityAdminInListViewModel : IMapFrom<Activity>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public string AddedByUserUserName { get; set; }

        public int UserActivitiesCount { get; set; }
    }
}
