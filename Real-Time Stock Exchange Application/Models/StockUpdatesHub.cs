using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Real_Time_Stock_Exchange_Application.Hubs
{
    public class StockUpdatesHub : Hub
    {
        public async Task SendStockUpdate(string symbol, decimal price)
        {
            // Broadcast the stock update to all clients
            await Clients.All.SendAsync("ReceiveStockUpdate", symbol, price);
        }
    }
}
