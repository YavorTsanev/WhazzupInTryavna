namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System;

    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class ActivityInListViewModel : IMapFrom<Activity>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CategoryImage { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public int CommentsCount { get; set; }
    }
}
