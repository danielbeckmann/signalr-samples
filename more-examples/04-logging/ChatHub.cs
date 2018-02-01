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

        public Task SendToGroup(string group, string name, string message)
        {
            return Clients.Group(group).InvokeAsync("broadcast", name, message);
        }

        public async Task JoinGroup(string groupName)
        {
            await Groups.AddAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).InvokeAsync("joinedGroup", groupName);
        }

        public async Task LeaveGroup(string groupName)
        {
            await Clients.Group(groupName).InvokeAsync("leftGroup", groupName);
            await Groups.RemoveAsync(Context.ConnectionId, groupName);
        }

        public override Task OnConnectedAsync()
        {
            return Clients.All.InvokeAsync("broadcast", "Admin", $"{Context.ConnectionId} Connected");
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return Clients.All.InvokeAsync("broadcast", "Admin", $"{Context.ConnectionId} Disconnected");
        }
    }
}
