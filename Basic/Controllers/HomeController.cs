using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Basic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize] //attribute use to guard an action "are you allow to come here"
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Authenticate() 
        {
            var authenticateClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "Bob"),
                new Claim(ClaimTypes.Email, "bob@gmail.com"),
                new Claim("Authentication.Says", "Okay let him in")
            }
            return RedirectToAction("Index");
        }
    }
}
