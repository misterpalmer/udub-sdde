using JetBrains.Annotations;
using Nuke.Common;
using static Nuke.Common.ChangeLog.ChangelogTasks;

namespace Sdde.BuildComponents;

[PublicAPI]
public interface IHasChangeLog : INukeBuild
{
    string ChangeLogFile => RootDirectory / "CHANGELOG.md";
    string NuGetReleaseNotes => GetNuGetReleaseNotes(ChangeLogFile, (this as IHasGitRepository)?.GitRepository);
}
