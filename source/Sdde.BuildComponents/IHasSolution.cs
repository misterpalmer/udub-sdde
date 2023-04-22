using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.ProjectModel;

namespace Sdde.BuildComponents;

public interface IHasSolution : INukeBuild
{
    [PublicAPI] [Solution] [Required] Solution Solution => TryGetValue(() => Solution);
}
