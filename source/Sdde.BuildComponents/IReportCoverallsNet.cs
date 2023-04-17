using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip.Compression;
using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.CI.AzurePipelines;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Codecov;
using Nuke.Common.Tools.ReportGenerator;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Tools.Codecov.CodecovTasks;
using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;
using Nuke.Common.Tools.CoverallsNet;
using static Nuke.Common.Tools.CoverallsNet.CoverallsNetTasks;


namespace Sdde.BuildComponents;

[PublicAPI]
public interface IReportCoverallsNet : ITest, IHasReports, IHasGitRepository
{
    bool CreateCoverageHtmlReport { get; }
    bool ReportToCoveralls { get; }
    [Parameter] [Secret] string CoverallsRepoToken => TryGetValue(() => CoverallsRepoToken);
    AbsolutePath CoverageReportDirectory => OutputDirectory / "coverage-reports";


    Target CoverAllsNet => _ => _
        .DependsOn(UnitTest)
        .TryAfter<ITest>()
        .Consumes(UnitTest)
        // .Produces(CoverageReportDirectory)
        .Requires(() => !ReportToCoveralls || CoverallsRepoToken != null)
        .Executes(() =>
        {
            if (CreateCoverageHtmlReport)
            {
                ReportGenerator(_ => _
                    .Apply(ReportGeneratorSettingsBase)
                    .Apply(ReportGeneratorSettings));

                // CompressZip(
                //         directory: CoverageReportDirectory,
                //         archiveFile: CoverageReportArchive,
                //         fileMode: FileMode.Create);
                // CoverageReportDirectory.ZipTo(CoverageReportDirectory, CoverageReportArchive, null, CompressionLevel.Optimal, fileMode: FileMode.Create);
            }

            if (ReportToCoveralls)
            {
                CoverallsNet(_ => _
                    .Apply(CoverallsNetSettingsBase)
                    .Apply(CoverallsNetSettings));

            }
        });

    sealed Configure<CoverallsNetSettings> CoverallsNetSettingsBase => _ => _
        .SetRepoToken(CoverallsRepoToken)
        // .SetUserRelativePaths(true)
        // .SetBasePath(TestResultDirectory)
        .SetOpenCover(true)
        .SetInput(TestResultDirectory / "Sdde.DataStructures.Tests.Unit-coverage.xml")
        .SetCommitBranch(GitRepository.Branch)
        .SetCommitId(GitRepository.Commit)
        .SetDryRun(false);

    Configure<CoverallsNetSettings> CoverallsNetSettings => _ => _;

    sealed Configure<ReportGeneratorSettings> ReportGeneratorSettingsBase => _ => _
        .SetTargetDirectory(CoverageReportDirectory)
        .SetReports(TestResultDirectory.GlobFiles("**/coverage.cobertura.xml").Select(x => x.ToString()))
        .SetReportTypes(ReportTypes.HtmlInline)
        .SetAssemblyFilters("-:*.Tests")
        .SetFramework("net7.0");

    Configure<ReportGeneratorSettings> ReportGeneratorSettings => _ => _;
}
