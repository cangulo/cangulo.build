using cangulo.build.abstractions.Models;
using cangulo.build.abstractions.Models.Enums;
using cangulo.build.Abstractions.NukeLogger;
using cangulo.build.Application.Requests;
using cangulo.build.domain;
using FluentResults;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace cangulo.build.Application.RequestHandlers
{
    public class IncreaseReleaseNumberRequestHandler : ICLIRequestHandler<IncreaseReleaseNumber, string>
    {
        private readonly INukeLogger _nukeLogger;
        private readonly IVersionParserService _versionService;

        public IncreaseReleaseNumberRequestHandler(INukeLogger nukeLogger, IVersionParserService versionService)
        {
            _nukeLogger = nukeLogger ?? throw new ArgumentNullException(nameof(nukeLogger));
            _versionService = versionService ?? throw new ArgumentNullException(nameof(versionService));
        }

        public async Task<Result<string>> Handle(IncreaseReleaseNumber request, CancellationToken cancellationToken)
        {
            var inputReleaseNumber = _versionService.ParseReleaseNumber(request.ReleaseNumber);
            _nukeLogger.Info($"current release number: {inputReleaseNumber}");

            var newReleaseNumber = ComputeNextVersion(request, inputReleaseNumber);

            _nukeLogger.Info($"increased program version: {newReleaseNumber}");

            return Result.Ok(newReleaseNumber.ToString());
        }

        private static ReleaseNumber ComputeNextVersion(IncreaseReleaseNumber request, ReleaseNumber inputReleaseNumber)
        {
            switch (request.IncreaseMode)
            {
                case IncreaseReleaseNumberModeEnum.Undefined:
                    throw new Exception("No increase mode provided");
                case IncreaseReleaseNumberModeEnum.Patch:
                    return new ReleaseNumber { Major = inputReleaseNumber.Major, Minor = inputReleaseNumber.Minor, Patch = inputReleaseNumber.Patch + 1 };
                case IncreaseReleaseNumberModeEnum.Minor:
                    return new ReleaseNumber { Major = inputReleaseNumber.Major, Minor = inputReleaseNumber.Minor + 1, Patch = 0 };
                case IncreaseReleaseNumberModeEnum.Major:
                    return new ReleaseNumber { Major = inputReleaseNumber.Major + 1, Minor = 0, Patch = 0 };
                default:
                    throw new Exception("No increase mode provided");
            }
        }
    }
}