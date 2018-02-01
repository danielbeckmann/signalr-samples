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
        private IHubContext<ChatHub> chatHubContext;

        public ChatBroadcastController(IHubContext<ChatHub> chatHubContext)
        {
            this.chatHubContext = chatHubContext;
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
            this.chatHubContext.Clients.All.InvokeAsync("broadcast", "Admin", value);
        }
    }
}
