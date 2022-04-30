using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using My_Project.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace My_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        public string AdminApiString;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            AdminApiString = _config.GetValue<string>("APISTRING");
        }

        public async Task<ActionResult> AdminLogin()
        {
            ViewBag.status = "";

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<ActionResult> AdminLogin(string User, string Pass)
        {
            if (!string.IsNullOrEmpty(User) && string.IsNullOrEmpty(Pass))
            {
                return RedirectToAction("AdminLogin");
            }
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            var str = HttpContext.Session.GetString("Admin");
            if (str == null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"Login?user={User}&pass={Pass}");
                if (httpResponse.IsSuccessStatusCode)
                {


                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    if (result == "true")
                    {
                        if (User == "Admin" && Pass == "admin123")
                        {
                            identity = new ClaimsIdentity(new[] {
                                          new Claim(ClaimTypes.Name, User),
                                          new Claim(ClaimTypes.Role, "Admin")
                                          }, CookieAuthenticationDefaults.AuthenticationScheme);
                            isAuthenticated = true;
                            if (isAuthenticated)
                            {
                                var principal = new ClaimsPrincipal(identity);

                                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                                ViewBag.status = "";
                                return LocalRedirect("~/Admin/Admin/ShowUser");
                            }
                            //HttpContext.Session.SetString("Admin", User);
                            //return RedirectToAction("ShowUser", "Admin");
                        }
                    }
                }
            }
            ViewBag.status = "Username or Password is incorrect";
            return View();
        }
    }
}
