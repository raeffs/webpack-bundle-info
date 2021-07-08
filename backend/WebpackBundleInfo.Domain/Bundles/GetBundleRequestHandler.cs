using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace WebpackBundleInfo.Bundles
{
    internal class GetBundleRequestHandler : IRequestHandler<GetBundleRequest, Bundle>
    {
        private readonly IDataContext context;

        public GetBundleRequestHandler(IDataContext context)
        {
            this.context = context;
        }

        public async Task<Bundle> Handle(GetBundleRequest request, CancellationToken cancellationToken)
        {
            var bundle = await this.context.Bundles.SingleAsync(x => x.CommitSha == request.CommitSha);
            return bundle;
        }
    }
}
