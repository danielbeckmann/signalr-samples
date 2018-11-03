using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace signalrdemo
{
    public interface IStatusTicker
    {
        Task StreamStatus(ChannelWriter<Status> writer, int count);
    }
}
