using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace signalrdemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Listen().Wait();
            Console.ReadLine();
        }

        private static async Task Listen()
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:56428/chat")
                .Build();

            connection.On<string>("broadcast", (message) =>
            {
                Console.WriteLine(message);
            });

            await connection.StartAsync();
            Console.WriteLine("Listening...");
        }
    }
}
