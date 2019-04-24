using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SignalRTest08
{
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    public class TestHub:Hub
    {
        public async Task SendMessage(string message)
        {
            var user = this.Context.User;
            ClaimsIdentity claimsIdentity = (ClaimsIdentity)user.Identity;
            foreach (var claim in claimsIdentity.Claims)
            {
                Console.WriteLine($"{claim.Type}=${claim.Value}");
            }


            await Clients.All.SendAsync("OnMsg", DateTime.Now, message);
        }

        public async Task AAA(string message,int age)
        {
            await Clients.All.SendAsync("OnMsg", DateTime.Now, message);
        }
    }
}
