using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebpackBundleInfo.Generic;

namespace WebpackBundleInfo.Bundles
{
    internal class GetBundlesRequestHandler : IRequestHandler<GetBundlesRequest, Page<BundleInfo>>
    {
        private readonly IDataContext context;

        public GetBundlesRequestHandler(IDataContext context)
        {
            this.context = context;
        }

        public async Task<Page<BundleInfo>> Handle(GetBundlesRequest request, CancellationToken cancellationToken)
        {
            var queryable = this.context.Bundles
                .OrderBy(x => x.CommitTimestamp)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new BundleInfo
                {
                    CommitSha = x.CommitSha,
                    CommitTimestamp = x.CommitTimestamp,
                    TotalGzipSize = x.TotalGzipSize,
                    TotalParsedSize = x.TotalParsedSize
                });

            return new Page<BundleInfo>
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalItems = await queryable.CountAsync(cancellationToken),
                Items = await queryable.ToListAsync(cancellationToken)
            };
        }
    }
}
