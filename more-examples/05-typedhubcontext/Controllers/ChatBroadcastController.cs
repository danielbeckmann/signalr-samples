using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace signalrdemo.Controllers
{
    [Route("api/[controller]")]
    public class ChatBroadcastController : Controller
    {
        private IHubContext<ChatHub, IChatHub> chatHubContext;

        public ChatBroadcastController(IHubContext<ChatHub, IChatHub> chatHubContext)
        {
            this.chatHubContext = chatHubContext;
        }

        [HttpGet]
        public void Get([FromQuery]string message)
        {
            this.chatHubContext.Clients.All.Broadcast("Admin", message);
        }
    }
}
