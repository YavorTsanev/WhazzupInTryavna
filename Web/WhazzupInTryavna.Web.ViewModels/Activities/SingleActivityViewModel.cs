namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class SingleActivityViewModel : IMapFrom<Activity>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Name { get; set; }

        public string CategoryName { get; set; }

        public string AddedByUserId { get; set; }

        public int CategoryActivitiesCount { get; set; }

        public string CategoryImage { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan TimeLeft => this.StartTime.ToLocalTime() - DateTime.Now;

        public string AddedByUserUserName { get; set; }

        public int UserActivitiesCount { get; set; }

        public double AvgVote { get; set; }

        public IEnumerable<UsersInActivity> UsersInActivity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Activity, SingleActivityViewModel>().ForMember(x => x.AvgVote, o => o.MapFrom(x => x.Votes.Count == 0 ? 0 : x.Votes.Average(x => x.Value)))
                .ForMember(x => x.UsersInActivity, o => o.MapFrom(x => x.UserActivities));
        }
    }
}
