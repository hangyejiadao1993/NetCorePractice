using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalRTest08.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.SignalR;

namespace SignalRTest08.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<TestHub> hubContext;

        public HomeController(IHubContext<TestHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public IActionResult Index()
        {
            long id = 8;
            string username = "yzk";
            var claims = new[]
            {
                new Claim("UserName",username),
                new Claim("UserId",id.ToString()),
                new Claim("DadName","马云")
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSettings.secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(JWTSettings.issuer, JWTSettings.audience, claims, expires: DateTime.Now.AddDays(30), signingCredentials: creds);
            var access_token = new JwtSecurityTokenHandler().WriteToken(token);
            ViewBag.access_token = access_token;
            return View();
        }

        public async Task<IActionResult> Test1()
        {
            await hubContext.Clients.All.SendAsync("OnMsg", DateTime.Now, "我来自Controller");
            return Content("OK" + DateTime.Now);
        }
    }
}
