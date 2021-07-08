namespace WhazzupInTryavna.Web.ViewModels.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using WhazzupInTryavna.Data.Models.Activities;
    using WhazzupInTryavna.Services.Mapping;

    public class UsersInActivity : IMapFrom<UserActivity>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<UserActivity, UsersInActivity>()
                .ForMember(x => x.Name, o => o.MapFrom(x => x.User.UserName));
        }
    }
}
