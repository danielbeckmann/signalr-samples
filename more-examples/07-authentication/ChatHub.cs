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
            return Clients.All.SendAsync("broadcast", $"{Context.UserIdentifier} ${message}");
        }

        [Authorize(Roles = "Admin")]
        public Task SendToUser(string user, string message)
        {
            return Clients.User(user).SendAsync("broadcast", message);
        }
    }
}
