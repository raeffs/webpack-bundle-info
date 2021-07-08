namespace WebpackBundleInfo.Bundles
{
    public record BundleInfo : BundleIdentifier
    {
        public long TotalParsedSize { get; init; }

        public long TotalGzipSize { get; init; }
    }
}
