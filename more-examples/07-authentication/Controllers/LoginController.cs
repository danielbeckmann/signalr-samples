using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace _01_basic_example.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        // GET: api/Login
        [HttpGet]
        public async Task<IActionResult> Get(string username)
        {
            var userClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, username)
            };

            if (username == "admin")
            {
                userClaims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else
            {
                userClaims.Add(new Claim(ClaimTypes.Role, "User"));
            }

            var principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, "CustomAuthorization"));
            await HttpContext.SignInAsync("MyCookieAuthenticationScheme", principal);
            return LocalRedirect("/");
        }
    }
}
