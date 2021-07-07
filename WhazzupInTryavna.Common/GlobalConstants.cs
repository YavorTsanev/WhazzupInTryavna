namespace WhazzupInTryavna.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Whazz up in Tryavna";
        public const string SiteUrl = "https://localhost:44319/";
        public const string AdminUsername = "Yavor";
        public const string AdministratorRoleName = "Administrator";
        public const string EmailForContact = "yavor.tsanev.1@gmail.com";
        public const string AdminEmail = "onq_koi_e@abv.bg";

        //// Data models requirements
        //// Category
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 20;
        public const string CategoryImageRegEx =
            @"(?:([^:\/?#]+):)?(?:\/\/([^\/?#]*))?([^?#]*\.(?:jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?";

        ////Activity
        public const int ActivityNameMinLength = 3;
        public const int ActivityNameMaxLength = 20;
        public const int ActivityLocationMinLength = 4;
        public const int ActivityLocationMaxLength = 20;


    }
}
