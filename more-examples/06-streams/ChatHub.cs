using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace signalrdemo
{
    public class ChatHub : Hub
    {
        private readonly IStatusTicker statusTicker;

        public ChatHub(IStatusTicker statusTicker)
        {
            this.statusTicker = statusTicker;
        }

        public Task Send(string message)
        {
            return Clients.All.SendAsync("broadcast", message);
        }

        public ChannelReader<Status> StreamStatus(int count)
        {
            var channel = Channel.CreateUnbounded<Status>();
             _ = this.statusTicker.StreamStatus(channel.Writer, count);
            return channel.Reader;
        }
    }
}
