using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WEB.Hubs
{      [HubName("NotificationHub")]
    public class NotificationHub : Hub
    {
        public void Send(String name, String message)
        {
            Clients.All.addNewMessageToPage(name, message);
        }
      

    }
}