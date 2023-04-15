using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;


using Sdde.BuildComponents;
using System.Collections.Generic;

public partial class Build : NukeBuild, ITest, IPack, IRestore, ICompile
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode

    // public static int Main () => Execute<Build>(x => ((IPack)x).Pack);
    public static int Main () => Execute<Build>(x => ((ITest)x).UnitTest);
    // public static int Main () => Execute<Build>(x => ((ICompile)x).Compile);

    // [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    // readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [CI] GitHubActions GitHubActions;

    Target Clean => _ => _
        .Before<IRestore>()
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            OutputDirectory.GlobDirectories("**/artifacts", "**/coberage-reports", "**/packages", "**/test-results").ForEach(DeleteDirectory);
            TemporaryDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);

        });

    IEnumerable<Nuke.Common.ProjectModel.Project> ITest.TestProjects => Partition.GetCurrent(Solution.GetProjects("*.Tests.*"));
}
