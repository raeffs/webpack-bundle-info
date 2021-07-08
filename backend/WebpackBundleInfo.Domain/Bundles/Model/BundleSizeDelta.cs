namespace WebpackBundleInfo.Bundles
{
    public record BundleSizeDelta
    {
        public long ParsedSize { get; init; }

        public long GzipSize { get; init; }
    }
}
