using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRSample.Server.HubConfigs
{
    public class SendHub : Hub
    {
        public async Task SendMessage(string sendMsg)
        {
            await Clients.All.SendAsync("send", sendMsg);
        }
    }
}
