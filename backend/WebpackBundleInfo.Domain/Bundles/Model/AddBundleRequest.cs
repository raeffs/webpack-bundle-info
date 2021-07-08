using MediatR;
using System;
using System.Collections.Generic;

namespace WebpackBundleInfo.Bundles
{
    public record AddBundleRequest : IRequest<Bundle>
    {
        public string CommitSha { get; init; } = string.Empty;

        public DateTimeOffset CommitTimestamp { get; init; }

        public ICollection<BundleComponent> Components { get; init; } = new List<BundleComponent>();
    }
}
