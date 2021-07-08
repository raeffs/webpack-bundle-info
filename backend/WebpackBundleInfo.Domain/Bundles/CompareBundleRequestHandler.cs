using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebpackBundleInfo.Bundles
{
    internal class CompareBundleRequestHandler : IRequestHandler<CompareBundleRequest, BundleSizeDelta>
    {
        private readonly IDataContext context;

        public CompareBundleRequestHandler(IDataContext context)
        {
            this.context = context;
        }

        public async Task<BundleSizeDelta> Handle(CompareBundleRequest request, CancellationToken cancellationToken)
        {
            var bundle = await this.context.Bundles.SingleAsync(x => x.CommitSha == request.CommitSha);

            return new BundleSizeDelta
            {
                ParsedSize = request.Components.Sum(x => x.ParsedSize) - bundle.TotalParsedSize,
                GzipSize = request.Components.Sum(x => x.GzipSize) - bundle.TotalGzipSize
            };
        }
    }
}
