namespace WhazzupInTryavna.Web.ViewModels.Administration.Users
{
    using System.Collections.Generic;

    public class UsersListingViewModel
    {
        public IEnumerable<UserInListViewModel> Users { get; set; }
    }
}
