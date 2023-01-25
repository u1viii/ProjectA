using Microsoft.AspNetCore.Builder;
using ProjectA.SignalR.Hubs;

namespace ProjectA.SignalR
{
    public static class MapHubsRegistration
    {
        public static void MapHubs(this WebApplication app)
        {
            app.MapHub<ProductHub>("/product-hub");
        }
    }
}
