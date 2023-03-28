using Nuke.Common;
using Nuke.Common.IO;

namespace Sdde.BuildComponents;

public interface IHasReports : IHasArtifacts
{
    AbsolutePath ReportDirectory => ArtifactsDirectory / "reports";
}