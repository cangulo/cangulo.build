using cangulo.build.Abstractions.Models;
using cangulo.build.Abstractions.NukeLogger;
using cangulo.build.Application.Requests;
using cangulo.build.Application.Requests.Enums;
using FluentResults;
using Nuke.Common;
using Octokit;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace cangulo.build.Application.RequestHandlers
{
    public class GetLastPRMergedIdRequestHandler : ICLIRequestHandler<GetLastPRMergedId, string>
    {
        private readonly INukeLogger _nukeLogger;
        private readonly BuildContext _buildContext;

        public GetLastPRMergedIdRequestHandler(INukeLogger nukeLogger, BuildContext buildContext)
        {
            _nukeLogger = nukeLogger ?? throw new ArgumentNullException(nameof(nukeLogger));
            _buildContext = buildContext ?? throw new ArgumentNullException(nameof(buildContext));
        }

        public async Task<Result<string>> Handle(GetLastPRMergedId request, CancellationToken cancellationToken)
        {
            var githubToken = EnvironmentInfo.GetVariable<string>(EnvVar.GITHUB_TOKEN.ToString());

            var client = new GitHubClient(new ProductHeaderValue(request.Originator));
            client.Credentials = new Credentials(githubToken);

            var prs = await client.PullRequest.GetAllForRepository(request.RepositoryId,
                new PullRequestRequest
                {
                    State = ItemStateFilter.Closed,
                    Base = request.TargetBranch
                },
                new ApiOptions
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                });

            if (!prs.Any())
                return Result.Fail($"No PR have been merged in the repository {request.RepositoryId}");

            var pr = prs.Single();
            _nukeLogger.Info($"Last PR Merged:" +
                $"\nRepository: {pr.Head.Repository.Name}" +
                $"\nsourceBranch: {pr.Head.Ref}" +
                $"\ntargetBranch: {pr.Base.Ref}" +
                $"\ntitle:{pr.Title}");

            return Result.Ok(pr.Id.ToString());
        }
    }
}