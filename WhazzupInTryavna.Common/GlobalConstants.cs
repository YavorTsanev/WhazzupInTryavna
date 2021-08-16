namespace WhazzupInTryavna.Common
{
    public static class GlobalConstants
    {
        public class AppConst
        {
            public const string SystemName = "Whazz up in Tryavna";
            public const string SiteUrl = "https://localhost:44319/";
            public const string EmailForContact = "yavor.tsanev.1@gmail.com";
            public const string PhoneNumberForContact = "+359 0894 66 ** **";
        }

        public class AdminConst
        {
            public const string Email = "onq_koi_e@abv.bg";
            public const string Username = "Yavor";
            public const string RoleName = "Administrator";
            public const string AreaName = "Administration";
        }

        public class UsersConst
        {
            public const string TestUserName1 = "TestUser1";
            public const string TestUser1Email = "TestUser1@.abv.bg";

            public const string TestUserName2 = "TestUser2";
            public const string TestUser2Email = "TestUser2@.abv.bg";
        }

        public class ErrorMessageConst
        {
            public const string CategoryDontExist = "Category don't exist";
            public const string AllowedExtensionError = "Only Image files allowed with extensions jpeg, jpg, gif, png!";
            public const string EmailNotValid = "Not valid email";
        }

        public class CategoryConst
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 30;
            public const string ImageRegEx = @"(?:([^:\/?#]+):)?(?:\/\/([^\/?#]*))?([^?#]*\.(?:jpeg|jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?";
        }

        public class ActivityConst
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 40;
            public const int LocationMinLength = 4;
            public const int LocationMaxLength = 40;
        }

        public class CommentConst
        {
            public const int ContentMinLength = 1;
            public const int ContentMaxLength = 120;
        }

        public class NewsConst
        {
            public const string ImageRegEx = @"(?:([^:\/?#]+):)?(?:\/\/([^\/?#]*))?([^?#]*\.(?:jpeg|jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?";
        }

        public class ContactConst
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 10;
            public const string EmailRegEx = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            public const int SubjectMinLength = 3;
            public const int SubjectMaxLength = 10;
            public const int MessageMinLength = 3;
            public const int MessageMaxLength = 1000;
        }
    }
}
