using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebSocketSharp.Server;

namespace connect4Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebSocketServer webSocketServer = new WebSocketServer("ws://localhost:43611");
            webSocketServer.Start();
            CreateHostBuilder(args).Build().Run();

            Console.ReadKey();
            webSocketServer.Stop();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
