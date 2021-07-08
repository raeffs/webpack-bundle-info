namespace WebpackBundleInfo.Bundles
{
    public class BundleComponent
    {
        public string Label { get; set; } = string.Empty;

        public long StatSize { get; set; }

        public long ParsedSize { get; set; }

        public long GzipSize { get; set; }
    }
}
