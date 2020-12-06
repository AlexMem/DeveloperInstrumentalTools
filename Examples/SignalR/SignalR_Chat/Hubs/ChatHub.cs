using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_Chat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Send", new { User = "test", Text = message });
        }
    }
}