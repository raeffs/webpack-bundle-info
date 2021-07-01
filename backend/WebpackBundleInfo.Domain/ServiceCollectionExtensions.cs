using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WebpackBundleInfo
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services
                .AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
