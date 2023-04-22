public partial class Build
{
    // Configure<DotNetBuildSettings> ICompile.CompileSettings => _ => _
    //     .When(!ScheduledTargets.Contains(((IPublish)this).Publish) && !ScheduledTargets.Contains(Install), _ => _
    //         .ClearProperties());
}
