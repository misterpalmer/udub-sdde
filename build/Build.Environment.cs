using System.Collections.Generic;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.GitVersion;
using Sdde.BuildComponents;


partial class Build : IHasSolution
{
    const string DebugConfiguration = "Debug";
    const string ReleaseConfiguration = "Release";
    const string Net70 = "net7.0";
    const string MainBranch = "main";
    const string DevelopBranch = "develop";
    const string ReleaseBranchPrefix = "release";
    const string FeatureBranchPrefix = "feature";
    const string IssueBranchPrefix = "issue";
    const string HotFixBranchPrefix = "hotfix";
    const string SupportBranchPrefix = "support";
    const string NuGetOrgSource = "https://api.nuget.org/v3/index.json";

    T From<T>() where T : INukeBuild => (T)(object)this;

    AbsolutePath SourceDirectory => RootDirectory / "source";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath OutputDirectory => RootDirectory / "output";
    AbsolutePath ArtifactsDirectory => OutputDirectory / "artifacts";
    AbsolutePath CoverageReportDirectory => OutputDirectory / "coberage-reports";
    AbsolutePath PackagesDirectory => OutputDirectory / "packages";
    AbsolutePath TestResultDirectory => OutputDirectory / "test-results";
    AbsolutePath ImagesDirectory => RootDirectory / "images";
    AbsolutePath ReleaseImageFile => ImagesDirectory / "release-image.png";
    AbsolutePath WatermarkImageFile => ImagesDirectory / "logo-watermark.png";

    GitVersion GitVersion => From<IHasGitVersion>().Versioning;
    GitRepository GitRepository => From<IHasGitRepository>().GitRepository;

    [Solution(GenerateProjects = true)] readonly Solution Solution;
    Nuke.Common.ProjectModel.Solution IHasSolution.Solution => Solution;
}
