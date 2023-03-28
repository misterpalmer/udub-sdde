﻿using JetBrains.Annotations;
using Nuke.Common;
using Nuke.Common.ChangeLog;
using Nuke.Common.CI.GitHubActions;
using Nuke.Common.Git;
using Nuke.Common.IO;
using Nuke.Common.Tools.GitHub;
using Nuke.Common.Utilities;
using Octokit;

namespace Sdde.BuildComponents;

[PublicAPI]
[ParameterPrefix(GitHubRelease)]
public interface ICreateGitHubRelease : IHasGitRepository, IHasChangeLog
{
    public const string GitHubRelease = nameof(GitHubRelease);

    [Parameter] [Secret] string Token => TryGetValue(() => Token) ?? GitHubActions.Instance.Token;
    string Version { get; }
    IEnumerable<AbsolutePath> AssetFiles { get; }

    Target CreateGitHubRelease => _ => _
        .Requires(() => Token)
        .Executes(async () =>
        {
            GitHubTasks.GitHubClient.Credentials = new Credentials(Token);

            var release = await GitHubTasks.GitHubClient.Repository.Release.Create(
                GitRepository.GetGitHubOwner(),
                GitRepository.GetGitHubName(),
                new NewRelease(Version)
                {
                    Name = $"v{Version}",
                    Body = ChangelogTasks.ExtractChangelogSectionNotes(NuGetReleaseNotes).JoinNewLine()
                });

            var uploadTasks = AssetFiles.Select(async x =>
            {
                await using var assetFile = File.OpenRead(x);
                var asset = new ReleaseAssetUpload
                {
                    FileName = x.Name,
                    ContentType = "application/octet-stream",
                    RawData = assetFile
                };
                await GitHubTasks.GitHubClient.Repository.Release.UploadAsset(release, asset);
            }).ToArray();

            Task.WaitAll(uploadTasks);
        });
}