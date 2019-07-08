using API.Data;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.HubNotify
{
    public class HubNotification : Hub
    {
        public async Task SendMessage(string userid, string message)
        {
            await Clients.User(userid).SendAsync(message);

        }
    }
}
