using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebpackBundleInfo.Bundles;

namespace WebpackBundleInfo
{
    internal class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<Bundle> Bundles { get; set; } = null!;

        public new Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}
