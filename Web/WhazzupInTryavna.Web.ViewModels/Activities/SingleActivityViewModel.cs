namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;
    using WhazzupInTryavna.Web.ViewModels.Comments;

    public class SingleActivityViewModel : ActivityBaseViewModel, IMapFrom<Activity>, IHaveCustomMappings, IActivityModel
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserId { get; set; }

        public string CategoryName { get; set; }

        public int CategoryActivitiesCount { get; set; }

        public string CategoryImage { get; set; }

        public TimeSpan TimeLeft => this.StartTime - DateTime.Now;

        public string AddedByUserUserName { get; set; }

        public int UserActivitiesCount { get; set; }

        public double AvgVote { get; set; }

        public IEnumerable<CommentInListViewModel> Comments { get; set; }

        public IEnumerable<UsersInActivityViewModel> UsersInActivity { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Activity, SingleActivityViewModel>().ForMember(x => x.AvgVote, o => o.MapFrom(x => x.Votes.Count == 0 ? 0 : x.Votes.Average(x => x.Value)))
                .ForMember(x => x.UsersInActivity, o => o.MapFrom(x => x.UserActivities));
        }
    }
}
