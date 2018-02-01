using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalrdemo
{
    [Authorize]
    public class ChatHub : Hub
    {
        public Task Send(string message)
        {
            return Clients.All.InvokeAsync("broadcast", message);
        }

        [Authorize(Roles = "Admin")]
        public Task SendToUser(string user, string message)
        {
            return Clients.User(user).InvokeAsync("broadcast", message);
        }
    }
}
