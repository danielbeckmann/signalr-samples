using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalrdemo
{
    public interface IStatusTicker
    {
        IObservable<Status> StreamStocks();
    }
}
