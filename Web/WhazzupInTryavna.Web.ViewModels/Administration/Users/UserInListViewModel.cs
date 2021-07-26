namespace WhazzupInTryavna.Web.ViewModels.Administration.Users
{
    using System;
    using WhazzupInTryavna.Data.Models;
    using WhazzupInTryavna.Services.Mapping;

    public class UserInListViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
