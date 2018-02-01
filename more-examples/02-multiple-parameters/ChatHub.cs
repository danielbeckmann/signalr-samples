using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalrdemo
{
    public class ChatHub : Hub
    {
        public Task Send(string name, string message)
        {
            return Clients.All.InvokeAsync("broadcast", name, message);
        }
    }
}
