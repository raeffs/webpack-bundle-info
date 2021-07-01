using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebpackBundleInfo.Bundles;

namespace WebpackBundleInfo
{
    public interface IDataContext : IDisposable
    {
        DbSet<Bundle> Bundles { get; }

        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
