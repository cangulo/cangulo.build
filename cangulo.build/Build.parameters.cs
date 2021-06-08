using cangulo.build.Application.Requests;
using Nuke.Common;

namespace cangulo.Build
{
    public partial class Build : NukeBuild
    {
        [Parameter("Please provide your request in JSON format")]
        private string RequestJSON { get; }

        private BaseCLIRequest Request { get; set; }
    }
}