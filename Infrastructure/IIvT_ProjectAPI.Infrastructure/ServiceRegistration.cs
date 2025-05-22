using IIvT_ProjectAPI.Application.Abstractions.Storage;
using IIvT_ProjectAPI.Application.Abstractions.Token;
using IIvT_ProjectAPI.Infrastructure.Storage;
using IIvT_ProjectAPI.Infrastructure.Token;
using Microsoft.Extensions.DependencyInjection;
using S = IIvT_ProjectAPI.Infrastructure.Storage;

namespace IIvT_ProjectAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IStorageService, StorageService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : S.Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
