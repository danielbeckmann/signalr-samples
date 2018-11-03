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
            return Clients.All.SendAsync("broadcast", name, message);
        }

        public Task SendToGroup(string group, string name, string message)
        {
            return Clients.Group(group).SendAsync("broadcast", name, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("joinedGroup", groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Clients.Group(groupName).SendAsync("leftGroup", groupName);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
