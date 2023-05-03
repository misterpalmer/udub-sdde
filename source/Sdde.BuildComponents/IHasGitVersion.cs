using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.Tools.GitVersion;

namespace Sdde.BuildComponents;

[PublicAPI]
public interface IHasGitVersion : INukeBuild
{
    [GitVersion(NoFetch = true)]
    [Required]
    GitVersion Versioning => TryGetValue(() => Versioning);
}
