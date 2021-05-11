using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WebSocketManager;

namespace connect4Web
{
    public class Connect4Handler : WebSocketHandler
    {
        public Connect4Handler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {

        }
    }
}
