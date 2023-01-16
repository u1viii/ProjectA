using Microsoft.Extensions.DependencyInjection;
using ProjectA.Application.Abstractions.Token;
using ProjectA.Infrastructure.Services.Token;

namespace ProjectA.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
        }
    }
}
