using cangulo.build.abstractions.Models.Enums;

namespace cangulo.build.Application.Requests
{
    public class IncreaseReleaseNumber : CLIRequest<string>
    {
        public string ReleaseNumber { get; set; }
        public IncreaseReleaseNumberModeEnum IncreaseMode { get; set; }
    }
}
