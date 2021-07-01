using System.Threading.Tasks;

namespace WebpackBundleInfo
{
    public interface IMigrator
    {
        Task MigrateDatabaseAsync();
    }
}
