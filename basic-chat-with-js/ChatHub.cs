using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ChatDemo
{
    public class ChatHub : Hub
    {
       public Task Send(string message)
        {
            return Clients.All.SendAsync("broadcast", message);
        }
    }
}
