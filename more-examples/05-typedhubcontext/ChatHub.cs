using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalrdemo
{
    public class ChatHub : Hub<IChatHub>
    {
        public Task Send(string name, string message)
        {
            return Clients.All.Broadcast(name, message);
        }

        public Task SendToGroup(string group, string name, string message)
        {
            return Clients.Group(group).Broadcast(name, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).JoinedGroup(groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Clients.Group(groupName).LeftGroup(groupName);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
