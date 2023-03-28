using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;


namespace Sdde.BuildComponents;

[PublicAPI]
public interface ICompile : IRestore, IHasConfiguration
{
    Target Compile => _ => _
        .Description("")
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(_ => _
                .Apply(CompileSettingsBase)
                .Apply(CompileSettings));
        });
    
    sealed Configure<DotNetBuildSettings> CompileSettingsBase => _ => _
        .SetProjectFile(Solution)
        .SetConfiguration(Configuration)
        .SetNoRestore(SucceededTargets.Contains(Restore))
        .When(IsServerBuild, _ => _
            .EnableContinuousIntegrationBuild())
        .SetNoRestore(SucceededTargets.Contains(Restore))
        .WhenNotNull(this as IHasGitRepository, (_, o) => _
            .SetRepositoryUrl(o.GitRepository.HttpsUrl))
        .WhenNotNull(this as IHasGitVersion, (_, o) => _
            .SetAssemblyVersion(o.Versioning.AssemblySemVer)
            .SetFileVersion(o.Versioning.AssemblySemFileVer)
            .SetInformationalVersion(o.Versioning.InformationalVersion));
    
    Configure<DotNetBuildSettings> CompileSettings => _ => _;
}