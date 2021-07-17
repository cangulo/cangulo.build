using cangulo.build.Abstractions.Models;
using cangulo.build.Application.Requests;
using cangulo.build.Application.Validators.Shared;
using FluentValidation;
using System.IO;

namespace cangulo.build.Application.Validators
{
    public class CreateReleaseValidator : AbstractValidator<CreateRelease>
    {
        public CreateReleaseValidator(BuildContext buildContext)
        {
            RuleFor(x => x.RepositoryId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(x => x.Tag)
                .NotEmpty();
            RuleFor(x => x.Title)
                .NotEmpty();
            RuleFor(x => x.ReleaseNotesFilePath)
                .NotEmpty()
                .Must(x => File.Exists(buildContext.RootDirectory / x))
                .WithMessage("The ReleaseNote file doesn't exists."); ;
            RuleFor(x => x.ReleaseAssetsFolder)
                .NotEmpty();
            RuleFor(x => CreateRelease.EnvVarsRequired)
                .NotNull()
                .ForEach(x => x.ValidateEnvVarIsProvided());
        }
    }
}