using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRSample.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder().WithUrl("https://localhost:5001/sample").Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            var messages = new List<string>();
            connection.On<string>("send", (message) => Console.WriteLine(message));

            await connection.StartAsync();

            while(true)
            {
                var msg = Console.ReadLine();
                if (string.IsNullOrEmpty(msg))
                    break;
                await connection.InvokeAsync("SendMessage", msg);
            }
        }
    }
}
