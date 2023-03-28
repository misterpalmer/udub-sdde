﻿using System.IO.Compression;
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


namespace Sdde.BuildComponents;

[PublicAPI]
public interface IReportCoverage : ITest, IHasReports, IHasGitRepository
{
    bool CreateCoverageHtmlReport { get; }
    bool ReportToCodecov { get; }
    [Parameter] [Secret] string CodecovToken => TryGetValue(() => CodecovToken);

    AbsolutePath CoverageReportDirectory => ReportDirectory / "coverage-report";
    AbsolutePath CoverageReportArchive => CoverageReportDirectory.WithExtension("zip");

    Target ReportCoverage => _ => _
        .DependsOn(Test)
        .TryAfter<ITest>()
        .Consumes(Test)
        .Produces(CoverageReportArchive)
        .Requires(() => !ReportToCodecov || CodecovToken != null)
        .Executes(() =>
        {
            if (ReportToCodecov)
            {
                Codecov(_ => _
                    .Apply(CodecovSettingsBase)
                    .Apply(CodecovSettings));
            }

            if (CreateCoverageHtmlReport)
            {
                ReportGenerator(_ => _
                    .Apply(ReportGeneratorSettingsBase)
                    .Apply(ReportGeneratorSettings));

                // CoverageReportDirectory.ZipTo(CoverageReportDirectory, CoverageReportArchive, null, CompressionLevel.Optimal, fileMode: FileMode.Create);
            }

            UploadCoverageData();
        });

    sealed Configure<CodecovSettings> CodecovSettingsBase => _ => _
        .SetFiles(TestResultDirectory.GlobFiles("*.xml").Select(x => x.ToString()))
        .SetToken(CodecovToken)
        .SetBranch(GitRepository.Branch)
        .SetSha(GitRepository.Commit)
        .WhenNotNull(this as IHasGitVersion, (_, o) => _
            .SetBuild(o.Versioning.FullSemVer))
        .SetFramework("netcoreapp3.0");

    Configure<CodecovSettings> CodecovSettings => _ => _;

    sealed Configure<ReportGeneratorSettings> ReportGeneratorSettingsBase => _ => _
        .SetReports(TestResultDirectory / "*.xml")
        .SetReportTypes(ReportTypes.HtmlInline)
        .SetTargetDirectory(CoverageReportDirectory)
        .SetFramework("netcoreapp2.1");

    Configure<ReportGeneratorSettings> ReportGeneratorSettings => _ => _;

    void UploadCoverageData()
    {
        TestResultDirectory.GlobFiles("*.xml").ForEach(x =>
            AzurePipelines.Instance?.PublishCodeCoverage(
                AzurePipelinesCodeCoverageToolType.Cobertura,
                x,
                CoverageReportDirectory));
    }
}