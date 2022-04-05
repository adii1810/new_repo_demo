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
        private readonly IConfiguration _config;
        public string AdminApiString;

        public ClientController(IConfiguration config, string adminApiString)
        {
            _config = config;
            AdminApiString = adminApiString;
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
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage response = await client.PostAsJsonAsync("AddRestaurant", vm);

            return View();
        }
    }
}
