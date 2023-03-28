using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;


namespace Sdde.BuildComponents;

[PublicAPI]
public interface IRestore : IHasSolution, INukeBuild
{
    [Parameter("Ignore unreachable sources during " + nameof(Restore))]
    
    Target Restore => _ => _
        .Description("")
        .Executes(() =>
        {
            DotNetRestore(_ => _
                .Apply(RestoreSettingsBase)
                .Apply(RestoreSettings));
        });
    
    sealed Configure<DotNetRestoreSettings> RestoreSettingsBase => _ => _
        .SetProjectFile(Solution);
        // .SetIgnoreFailedSources(IgnoreFailedSources);

    Configure<DotNetRestoreSettings> RestoreSettings => _ => _;
    bool IgnoreFailedSources => TryGetValue<bool?>(() => IgnoreFailedSources) ?? false;
}