using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return Clients.All.InvokeAsync("broadcast", message);
        }

        public IObservable<Status> StreamStatus()
        {
            return this.statusTicker.StreamStocks();
        }
    }
}
