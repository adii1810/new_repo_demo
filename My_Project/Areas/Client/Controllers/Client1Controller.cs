using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using My_Project.Areas.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace My_Project.Areas.Client.Controllers
{
    [Area("Client")]
    public class Client1Controller : Controller
    {
        private readonly IConfiguration _config;
        public string AdminApiString;

        public Client1Controller(IConfiguration config, string adminApiString)
        {
            _config = config;
            AdminApiString = adminApiString;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Index2()
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
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(AdminApiString);
            //HttpResponseMessage response = await client.PostAsJsonAsync("AddRestaurant", vm);
            //if (response.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}

            return View();
        }
    }
}
