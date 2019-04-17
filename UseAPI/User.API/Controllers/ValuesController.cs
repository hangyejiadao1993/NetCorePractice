using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.API.Data;
 
using Microsoft.EntityFrameworkCore;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        private UserContext _userContext;
        public ValuesController(UserContext userContext)
        {
            _userContext = userContext;
        }

         
        [HttpGet]
        public async Task<IActionResult> GetValue()
        {
            return  Json(await _userContext.Users.SingleOrDefaultAsync(p => p.Name == "jesse"));
        }

        
    }
}
