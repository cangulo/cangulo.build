using cangulo.build.abstractions.Models.Enums;
using System.Collections.Generic;

namespace cangulo.build.abstractions
{
    public static class Constants
    {
        public static class RegexConstants
        {
            public const string REGEX_NUGET_VERSION = @"([\d]{1,2})\.([\d]{1,2})\.([\d]{1,2})\.([\d]{1,2})";
            public const string RELEASE_VERSION = @"^([\d]{1,2})\.([\d]{1,2})\.([\d]{1,2})(.*)?";
        }

        public static class CSProjProperties
        {
            public const string VERSION_PREFIX = "VersionPrefix";
            public const string IS_PACKABLE = "IsPackable";
        }

        public static IDictionary<CommitActionEnum, string> CommitActionsVsMsg =
            new Dictionary<CommitActionEnum, string>
            {
                {CommitActionEnum.CreatePatch, @"\[ci\][\s]+create[\s]+patch" },
                {CommitActionEnum.CreateMinor, @"\[ci\][\s]+create[\s]+minor" },
                {CommitActionEnum.CreateMajor, @"\[ci\][\s]+create[\s]+major" },
            };
    }
}