using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.Codecov;
using Nuke.Common.Tools.CoverallsNet;
using Nuke.Common.Tools.ReportGenerator;
using static Nuke.Common.Tools.ReportGenerator.ReportGeneratorTasks;
using static Nuke.Common.Tools.CoverallsNet.CoverallsNetTasks;
using static Nuke.Common.Tools.Codecov.CodecovTasks;


namespace Sdde.BuildComponents;

[PublicAPI]
public interface IReportCoverallsNet : ITest, IHasReports, IHasGitRepository
{
    bool CreateCoverageHtmlReport { get; }
    bool ReportToCoveralls { get; }
    bool ReportToCodecov { get; }
    [Parameter] [Secret] string CoverallsRepoToken => TryGetValue(() => CoverallsRepoToken);
    [Parameter] [Secret] string CodecovToken => TryGetValue(() => CodecovToken);
    AbsolutePath CoverageReportDirectory => OutputDirectory / "coverage-reports";


    Target CoverallsDotIo => _ => _
        .DependsOn(UnitTest)
        .TryAfter<ITest>()
        .Consumes(UnitTest)
        // .Produces(CoverageReportDirectory)
        .Requires(() => !ReportToCoveralls || CoverallsRepoToken != null)
        .Executes(() =>
        {
            if (CreateCoverageHtmlReport)
                ReportGenerator(_ => _
                    .Apply(ReportGeneratorSettingsBase)
                    .Apply(ReportGeneratorSettings));
            if (ReportToCodecov)
                Codecov(_ => _
                    .Apply(CodecovSettingsBase)
                    .Apply(CodecovSettings));

            if (ReportToCoveralls)
                CoverallsNet(_ => _
                    .Apply(CoverallsNetSettingsBase)
                    .Apply(CoverallsNetSettings));
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

    sealed Configure<CodecovSettings> CodecovSettingsBase => _ => _
        .SetFiles(TestResultDirectory.GlobFiles("**/coverage.cobertura.xml").Select(x => x.ToString()))
        .SetToken(CodecovToken)
        .SetBranch(GitRepository.Branch)
        .SetSha(GitRepository.Commit)
        .WhenNotNull(this as IHasGitVersion, (_, o) => _
            .SetBuild(o.Versioning.FullSemVer))
        .SetFramework("net5.0");

    Configure<CodecovSettings> CodecovSettings => _ => _;

    Configure<CoverallsNetSettings> CoverallsNetSettings => _ => _;

    sealed Configure<ReportGeneratorSettings> ReportGeneratorSettingsBase => _ => _
        .SetTargetDirectory(CoverageReportDirectory)
        .SetReports(TestResultDirectory.GlobFiles("**/coverage.cobertura.xml").Select(x => x.ToString()))
        .SetReportTypes(ReportTypes.HtmlInline)
        .SetAssemblyFilters("-:*.Tests")
        .SetFramework("net7.0");

    Configure<ReportGeneratorSettings> ReportGeneratorSettings => _ => _;
}
