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
// [GitHubActions(
//     "deployment",
//     GitHubActionsImage.UbuntuLatest,
//     AutoGenerate = true,
//     Submodules = GitHubActionsSubmodules.Recursive,
//     FetchDepth = 0,
//     On = new[] { GitHubActionsTrigger.PullRequest },
//     PublishArtifacts = true,
//     InvokedTargets = new[] { nameof(IPublish.Publish) },
//     CacheKeyFiles = new[] { "global.json", "source/**/*.csproj" },
//     EnableGitHubToken = true)]
partial class Build
{

}
