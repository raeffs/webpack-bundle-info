using MediatR;

namespace WebpackBundleInfo.Bundles
{
    public record GetBundleRequest : IRequest<Bundle>
    {
        public string CommitSha { get; init; } = string.Empty;
    }
}
