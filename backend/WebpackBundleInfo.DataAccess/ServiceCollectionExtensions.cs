using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebpackBundleInfo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, string connectionString)
        {
            return services
                .AddTransient<IMigrator, Migrator>()
                .AddTransient<IDataContext, DataContext>()
                .AddDbContext<DataContext>(options =>
                {
                    options
                        .UseSqlServer(connectionString)
                        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                });
        }
    }
}
