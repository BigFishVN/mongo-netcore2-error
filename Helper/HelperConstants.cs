namespace Helper
{
    public class HelperConstants
    {
        public const string DefaultLanguageCode = "en-us";

        public const string PermissionCodeClaimsType = "PermissionCode";

        public static string AuthorizationHeaderName => "Authorization";

        public static string BearerAuthenName => "Bearer";

        public static int MobileTokenTimeout => 365;

        public static int TokenTimeout => 7;
    }
}