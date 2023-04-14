using Nuke.Common;
using Nuke.Common.IO;

namespace Sdde.BuildComponents;

public interface IHasArtifacts : INukeBuild
{
    AbsolutePath OutputDirectory => RootDirectory / "output";
    AbsolutePath PackagesDirectory => OutputDirectory / "packages";
    AbsolutePath ArtifactsDirectory => OutputDirectory / "artifacts";
}
