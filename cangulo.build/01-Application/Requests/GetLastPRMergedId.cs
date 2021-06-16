using cangulo.build.Application.Requests.Enums;

namespace cangulo.build.Application.Requests
{
    public class GetLastPRMergedId : CLIRequest<string>
    {
        public long RepositoryId { get; set; }
        public string TargetBranch { get; set; }
        public static new EnvVar[] EnvVarsRequired = new EnvVar[] { EnvVar.GITHUB_TOKEN, EnvVar.OUTPUT_FILE_PATH };
    }
}