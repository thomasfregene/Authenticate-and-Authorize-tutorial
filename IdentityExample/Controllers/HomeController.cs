using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize] //attribute use to guard an action "are you allow to come here"
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }

        public async Task<IActionResult> Login(string username, string password)
        {
            //login functionality
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                //sign in
                var signInresult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInresult.Succeeded)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(string username, string password)
        {
            //Register functionality
            var user = new IdentityUser()
            {
                UserName = username,
                Email = ""
            };
            //create user in db
            var result = await _userManager.CreateAsync(user, password);

            //sign up
            var signInresult = await _signInManager.PasswordSignInAsync(user, password, false, false);

            if (signInresult.Succeeded)
            {

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
