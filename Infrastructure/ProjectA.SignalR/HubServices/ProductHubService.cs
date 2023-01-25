using Microsoft.AspNetCore.SignalR;
using ProjectA.Application.Abstractions.Hubs;
using ProjectA.SignalR.Hubs;

namespace ProjectA.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {
        readonly IHubContext<ProductHub> _hubContext;

        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync(ReciveFunctionNames.ProductAdded, message);
        }
    }
}
