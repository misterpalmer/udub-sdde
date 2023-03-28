using Nuke.Common;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Sdde.BuildComponents;


public partial class Build
{
    // Configure<DotNetBuildSettings> ICompile.CompileSettings => _ => _
    //     .When(!ScheduledTargets.Contains(((IPublish)this).Publish) && !ScheduledTargets.Contains(Install), _ => _
    //         .ClearProperties());
}