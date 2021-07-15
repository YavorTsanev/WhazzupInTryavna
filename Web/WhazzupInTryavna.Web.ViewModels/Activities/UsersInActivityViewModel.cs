namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using AutoMapper;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class UsersInActivityViewModel : IMapFrom<UserActivity>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserActivity, UsersInActivityViewModel>()
                .ForMember(x => x.Name, o => o.MapFrom(x => x.User.UserName));
        }
    }
}
