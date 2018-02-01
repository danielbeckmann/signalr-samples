using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace signalrdemo
{
    public class StatusTicker : IStatusTicker
    {
        public IObservable<Status> StreamStocks()
        {
            return Observable.Create(
                async (IObserver<Status> observer) =>
                {
                    while (true)
                    {
                        var status = new Status { Time = DateTime.Now.ToString("HH:mm:ss") };
                        observer.OnNext(status);
                        await Task.Delay(TimeSpan.FromSeconds(5));
                    }
                });
        }
    }
}
