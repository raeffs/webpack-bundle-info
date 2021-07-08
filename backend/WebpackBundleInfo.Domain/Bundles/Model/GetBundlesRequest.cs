using MediatR;
using WebpackBundleInfo.Generic;

namespace WebpackBundleInfo.Bundles
{
    public record GetBundlesRequest : IRequest<Page<BundleInfo>>
    {
        public int PageSize { get; init; } = 100;
        public int PageNumber { get; init; } = 1;
    }
}
