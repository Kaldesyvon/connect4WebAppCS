using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using connect4Core.Core;
using Microsoft.AspNetCore.SignalR;

namespace connect4Web.Hubs
{
    public class Connect4Hub : Hub
    {
        public async Task SendTask(int column, Color color)
        {
            await Clients.All.SendAsync("AddStone", column, color);
        }
    }
}
