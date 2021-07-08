using System;
using System.Collections.Generic;

namespace WebpackBundleInfo.Bundles
{
    public class Bundle
    {
        public string CommitSha { get; set; } = string.Empty;

        public DateTimeOffset CommitTimestamp { get; set; }

        public long TotalParsedSize { get; set; }

        public long TotalGzipSize { get; set; }

        public ICollection<BundleComponent> Components { get; set; } = new List<BundleComponent>();
    }
}
