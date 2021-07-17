using cangulo.build.abstractions.Models.Enums;
using cangulo.build.Application.Requests;
using FluentValidation;
using static cangulo.build.abstractions.Constants;

namespace cangulo.build.Application.Validators
{
    public class IncreaseReleaseNumberRequestValidator : AbstractValidator<IncreaseReleaseNumber>
    {
        public IncreaseReleaseNumberRequestValidator()
        {
            RuleFor(x => x.ReleaseNumber)
                .NotNull()
                .Matches(RegexConstants.RELEASE_VERSION);
            RuleFor(x => x.IncreaseMode)
                .NotEmpty()
                .Must(x => x != IncreaseReleaseNumberModeEnum.Undefined);
        }
    }
}
