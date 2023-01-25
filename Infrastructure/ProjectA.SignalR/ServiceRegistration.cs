using Microsoft.Extensions.DependencyInjection;
using ProjectA.Application.Abstractions.Hubs;
using ProjectA.SignalR.HubServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectA.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddScoped<IProductHubService, ProductHubService>();
            services.AddSignalR();
        }
    }
}
