namespace WhazzupInTryavna.IntegrationTests.Data
{
    using WhazzupInTryavna.Web.ViewModels.Home;

    public static class HomeData
    {
        public static HomeViewModel GetHomeViewModel()
        {
            return new()
            {
                ActivitiesCount = 5,
                NewsCount = 5,
                UsersCount = 5
            };
        }
    }
}
