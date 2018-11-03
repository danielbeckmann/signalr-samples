using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace signalrdemo
{
    public class StatusTicker : IStatusTicker
    {
        public async Task StreamStatus(ChannelWriter<Status> writer, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var status = new Status { Time = DateTime.Now.ToString("HH:mm:ss") };
                await writer.WriteAsync(status);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}
