using JwtIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JwtIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByEmailAsync("bilalkeremoglu@gmail.com");

            var signInResult = await _signInManager.PasswordSignInAsync(user, "123456Bb", true, false);


            return View();
        }
        [Authorize]
        public async Task<IActionResult> Privacy()
        {
            var user = new User
            {
                isActive = true,
                Surname = "Keremoglu",
                Email = "bilalkeremoglu@gmail.com",
                Name = "bilal",
                UserName = "bilalk"
            };
            var RHeaders = HttpContext.Request.Headers;
            //var result = await _userManager.CreateAsync(user, "123456Bb");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
