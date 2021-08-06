namespace WhazzupInTryavna.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "Whazz up in Tryavna";
        public const string SiteUrl = "https://localhost:44319/";
        public const string AdminUsername = "Yavor";
        public const string AdministratorRoleName = "Administrator";
        public const string AdministrationAreaName = "Administration";
        public const string EmailForContact = "yavor.tsanev.1@gmail.com";
        public const string PhoneNumberForContact = "+359 0894 66 ** **";
        public const string AdminEmail = "onq_koi_e@abv.bg";

        //// Error messages
        public const string CategoryDontExist = "Category don't exist";
        public const string AllowedExtensionError = "Only Image files allowed with extensions jpeg, jpg, gif, png!";
        public const string EmailNotValid = "Not valid email";

        //// Data models requirements

        //// Category
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 30;
        public const string CategoryImageRegEx = @"(?:([^:\/?#]+):)?(?:\/\/([^\/?#]*))?([^?#]*\.(?:jpeg|jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?";

        ////Activity
        public const int ActivityNameMinLength = 3;
        public const int ActivityNameMaxLength = 40;
        public const int ActivityLocationMinLength = 4;
        public const int ActivityLocationMaxLength = 40;

        ////Comment
        public const int CommentContentMinLength = 1;
        public const int CommentContentMaxLength = 120;

        ////News
        public const string NewsImageRegEx = @"(?:([^:\/?#]+):)?(?:\/\/([^\/?#]*))?([^?#]*\.(?:jpeg|jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?";

        ////Contact
        public const int ContactNameMinLength = 2;
        public const int ContactNameMaxLength = 10;
        public const string ContactEmailRegEx = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public const int ContactSubjectMinLength = 3;
        public const int ContactSubjectMaxLength = 10;
        public const int ContactMessageMinLength = 3;
        public const int ContactMessageMaxLength = 1000;
    }
}
