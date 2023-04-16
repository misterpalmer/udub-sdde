using Nuke.Common;
using Nuke.Common.CI.GitHubActions;
using Sdde.BuildComponents;


[GitHubActions(
    "continuous",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = true,
    Submodules = GitHubActionsSubmodules.Recursive,
    FetchDepth = 0,
    OnPushBranchesIgnore = new[] { MainBranch, DevelopBranch, $"{ReleaseBranchPrefix}/*" },
    OnPullRequestBranches = new[] { DevelopBranch, $"{ReleaseBranchPrefix}/*", $"{FeatureBranchPrefix}/*" },
    PublishArtifacts = true,
    InvokedTargets = new[] { nameof(ITest.UnitTest), nameof(IPack.Pack) },
    // InvokedTargets = new[] { nameof(IPack.Pack) },
    // InvokedTargets = new[] { nameof(ITest.Test) },
    // InvokedTargets = new[] { nameof(ICompile.Compile) },
    // InvokedTargets = new[] { nameof(IRestore.Restore) },
    CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" },
    EnableGitHubToken = true,
    OnPushExcludePaths = new [] { "**/README.md"})]
[GitHubActions(
    "coverage",
    GitHubActionsImage.UbuntuLatest,
    AutoGenerate = true,
    Submodules = GitHubActionsSubmodules.Recursive,
    FetchDepth = 0,
    On = new[] { GitHubActionsTrigger.WorkflowDispatch },
    PublishArtifacts = true,
    InvokedTargets = new[] { nameof(IReportCoverage.ReportCoverage) },
    CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" },
    EnableGitHubToken = true)]
// [GitHubActions(
//     "coveralls",
//     GitHubActionsImage.UbuntuLatest,
//     AutoGenerate = true,
//     Submodules = GitHubActionsSubmodules.Recursive,
//     FetchDepth = 0,
//     On = new[] { GitHubActionsTrigger.WorkflowDispatch },
//     PublishArtifacts = false,
//     InvokedTargets = new[] { nameof(IReportCoverallsNet.CoverAllsNet) },
//     CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" },
//     EnableGitHubToken = true,
//     ImportSecrets = new[] { nameof(CoverallsRepoToken) })]
// [GitHubActions(
//     "combined-coverage",
//     GitHubActionsImage.UbuntuLatest,
//     AutoGenerate = true,
//     Submodules = GitHubActionsSubmodules.Recursive,
//     FetchDepth = 0,
//     On = new[] { GitHubActionsTrigger.WorkflowDispatch },
//     PublishArtifacts = true,
//     InvokedTargets = new[] { nameof(IReportCoverage.ReportCoverage), nameof(IReportCoverallsNet.CoverAllsNet)  },
//     CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" },
//     EnableGitHubToken = true,
//     ImportSecrets = new[] { nameof(CoverallsRepoToken) })]
partial class Build
{

}
