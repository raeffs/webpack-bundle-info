using System;

namespace WebpackBundleInfo.Bundles
{
    public record BundleIdentifier
    {
        public string CommitSha { get; init; } = string.Empty;

        public DateTimeOffset CommitTimestamp { get; init; }
    }
}
