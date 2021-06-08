namespace cangulo.build.Abstractions
{
    public class Constants
    {
        public static class RegexConstants
        {
            public const string REGEX_NUGET_VERSION = @"([\d]{1,2})\.([\d]{1,2})\.([\d]{1,2})\.([\d]{1,2})";
        }

        public static class CSProjProperties
        {
            public const string VERSION_PREFIX = "VersionPrefix";
            public const string IS_PACKABLE = "IsPackable";
        }
    }
}