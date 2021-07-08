using MediatR;
using System.Collections.Generic;

namespace WebpackBundleInfo.Bundles
{
    public record CompareBundleRequest : IRequest<BundleSizeDelta>
    {
        public string CommitSha { get; init; } = string.Empty;

        public ICollection<BundleComponent> Components { get; init; } = new List<BundleComponent>();
    }
}
