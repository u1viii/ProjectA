using Microsoft.Extensions.DependencyInjection;
using ProjectA.Application.Abstractions.Services.Storage;
using ProjectA.Application.Abstractions.Token;
using ProjectA.Application.Enums;
using ProjectA.Infrastructure.Services.Storage;
using ProjectA.Infrastructure.Services.Storage.GoogleCloud;
using ProjectA.Infrastructure.Services.Storage.Local;
using ProjectA.Infrastructure.Services.Token;

namespace ProjectA.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IStorageService, StorageService>();
        }
        public static void AddStorage<T>(this IServiceCollection services) where T : class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
        public static void AddStorage(this IServiceCollection services, StorageTypes storage)
        {
            switch (storage)
            {
                case StorageTypes.Local:
                    services.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageTypes.GoogleCloud:
                    services.AddScoped<IStorage, GoogleCloudStorage>();
                    break;
                default:
                    break;
            }
        }
    }
}
