using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebpackBundleInfo.Bundles
{
    internal class AddBundleRequestHandler : IRequestHandler<AddBundleRequest, Bundle>
    {
        private readonly IDataContext context;

        public AddBundleRequestHandler(IDataContext context)
        {
            this.context = context;
        }

        public async Task<Bundle> Handle(AddBundleRequest request, CancellationToken cancellationToken)
        {
            var bundle = new Bundle
            {
                CommitSha = request.CommitSha,
                CommitTimestamp = request.CommitTimestamp,
                Components = request.Components,
                TotalParsedSize = request.Components.Sum(x => x.ParsedSize),
                TotalGzipSize = request.Components.Sum(x => x.GzipSize)
            };

            this.context.Bundles.Add(bundle);

            await this.context.SaveChangesAsync(cancellationToken);

            return bundle;
        }
    }
}
