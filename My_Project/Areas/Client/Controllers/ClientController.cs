using EmailServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using My_Project.Areas.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace My_Project.Controllers
{
    [Area("Client")]
    public class ClientController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;
        public string RestaurantApiString;
        public ClientController(IEmailSender emailSender, IConfiguration config)
        {
            _emailSender = emailSender;
            _config = config;
            RestaurantApiString = _config.GetValue<string>("RESTAURANTAPISTRING");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VendorReg()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VendorReg(RestaurantDetailViewModel vm)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage response = await client.PostAsJsonAsync("AddRestaurant", vm);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
