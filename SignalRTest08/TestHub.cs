using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRTest08
{
    public class TestHub:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("OnMsg", DateTime.Now, message);
        }

        public async Task AAA(string message,int age)
        {
            await Clients.All.SendAsync("OnMsg", DateTime.Now, message);
        }
    }
}
