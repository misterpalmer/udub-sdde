using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace Sdde.BuildComponents;

[PublicAPI]
public interface IPack : INukeBuild, ICompile, IHasArtifacts
{
    Target Pack => _ => _
        .Description("")
        .DependsOn(Compile)
        .Produces(PackagesDirectory / "*.nupkg")
        .Executes(() =>
        {
            DotNetPack(_ => _
                .Apply(PackSettingsBase)
                .Apply(PackSettings));

            // ReportSummary(_ => _
            //     .AddPair("Packages", PackagesDirectory.GlobFiles("*.nupkg").Count.ToString()));
        });
    
    sealed Configure<DotNetPackSettings> PackSettingsBase => _ => _
        .SetProject(Solution)
        .SetConfiguration(Configuration)
        .SetNoBuild(SucceededTargets.Contains(Compile))
        .SetOutputDirectory(PackagesDirectory)
        .WhenNotNull(this as IHasGitRepository, (_, o) => _
            .SetRepositoryUrl(o.GitRepository.HttpsUrl))
        .WhenNotNull(this as IHasGitVersion, (_, o) => _
            .SetVersion(o.Versioning.NuGetVersionV2))
        .WhenNotNull(this as IHasChangeLog, (_, o) => _
            .SetPackageReleaseNotes(o.NuGetReleaseNotes));

    Configure<DotNetPackSettings> PackSettings => _ => _;
}