using cangulo.build.abstractions;
using cangulo.build.abstractions.Models;
using System;
using System.Text.RegularExpressions;
using static cangulo.build.abstractions.Constants;

namespace cangulo.build.domain
{
    public interface IVersionParserService
    {
        ReleaseNumber ParseReleaseNumber(string version);
        ReleaseNumber ParseVersionFromTag(string tag);
    }

    public class VersionParserService : IVersionParserService
    {
        public ReleaseNumber ParseReleaseNumber(string version)
        {
            var match = Regex.Match(version, RegexConstants.RELEASE_VERSION);
            if (match.Success)
            {
                return new ReleaseNumber
                {
                    Major = int.Parse(match.Groups[1].Value),
                    Minor = int.Parse(match.Groups[2].Value),
                    Patch = int.Parse(match.Groups[3].Value),
                    Extra = match.Groups[4].Value
                };
            }
            throw new Exception($"version {version} doesn't have a valid format");
        }

        public ReleaseNumber ParseVersionFromTag(string tag)
            => new ReleaseNumber
            {
                Major = int.Parse(tag.Split(".")[0]),
                Minor = int.Parse(tag.Split(".")[1]),
                Patch = int.Parse(tag.Split(".")[2])
            };
    }
}