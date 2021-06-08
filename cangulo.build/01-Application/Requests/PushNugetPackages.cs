namespace cangulo.build.Application.Requests
{
    public class PushNugetPackages : CLIRequest
    {
        public string NugetPackagesLocation { get; set; }
        public string TargetNugetRepository { get; set; }
    }
}