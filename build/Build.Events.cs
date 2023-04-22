using Serilog;

partial class Build
{
    protected override void OnBuildInitialized()
    {
        Log.Information("🚀 Build process Initialized");
        base.OnBuildInitialized();
    }

    protected override void OnBuildCreated()
    {
        Log.Information("🚀 Build process Created");
        base.OnBuildCreated();
    }

    protected override void OnBuildFinished()
    {
        Log.Information("🚀 Build process Finished");
        base.OnBuildFinished();
    }

    protected override void OnTargetRunning(string target)
    {
        Log.Information($"Target {target} Running");
        base.OnTargetRunning(target);
    }

    protected override void OnTargetSucceeded(string target)
    {
        Log.Information($"Target {target} Succeeded");
        base.OnTargetRunning(target);
    }

    protected override void OnTargetFailed(string target)
    {
        Log.Information($"Target {target} Failed");
        base.OnTargetRunning(target);
    }

    protected override void OnTargetSkipped(string target)
    {
        Log.Information($"Target {target} Skipped");
        base.OnTargetRunning(target);
    }
}
