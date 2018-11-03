using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalrdemo
{
    public interface IChatHub
    {
        Task Broadcast(string name, string message);
        Task JoinedGroup(string group);
        Task LeftGroup(string group);

    }
}
