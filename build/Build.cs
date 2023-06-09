using System.Collections.Generic;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities.Collections;
using Sdde.BuildComponents;
using static Nuke.Common.IO.FileSystemTasks;


public partial class Build : NukeBuild, ITest, IPack, IRestore, ICompile, IReportCoverage, IReportCoverallsNet
{
    // public static int Main () => Execute<Build>(x => ((ICompile)x).Compile);

    // [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    // readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [CI] GitHubActions GitHubActions;

    Target Clean => _ => _
        .Before<IRestore>()
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").DeleteDirectories();
            TestsDirectory.GlobDirectories("**/bin", "**/obj").DeleteDirectories();
            OutputDirectory
                .GlobDirectories("**/artifacts", "**/coverage-reports", "**/packages", "**/test-results")
                .DeleteDirectories();
            TemporaryDirectory.GlobDirectories("**/bin", "**/obj").DeleteDirectories();
        });

    public bool CreateCoverageHtmlReport => true;
    public bool ReportToCodecov => true;
    public bool ReportToCoveralls => true;

    IEnumerable<Project> ITest.TestProjects => Partition.GetCurrent(Solution.GetAllProjects("*.Tests.*"));

    /// Support plugins are available for:
    /// - JetBrains ReSharper        https://nuke.build/resharper
    /// - JetBrains Rider            https://nuke.build/rider
    /// - Microsoft VisualStudio     https://nuke.build/visualstudio
    /// - Microsoft VSCode           https://nuke.build/vscode

    // public static int Main () => Execute<Build>(x => ((IPack)x).Pack);
    public static int Main() => Execute<Build>(x => ((ITest) x).UnitTest);
}
