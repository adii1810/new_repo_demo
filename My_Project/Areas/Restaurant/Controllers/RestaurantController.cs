using EmailServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using My_Project.Areas.Admin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace My_Project.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;
        public string AdminApiString;
        public string RestaurantApiString;
        public RestaurantController(IEmailSender emailSender, IConfiguration config)
        {
            _emailSender = emailSender;
            _config = config;
            AdminApiString = _config.GetValue<string>("APISTRING");
            RestaurantApiString = _config.GetValue<string>("RESTAURANTAPISTRING");
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShowProduct()
        {
            CategoryViewModel vm = new CategoryViewModel();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"Category");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                List<SelectListItem> enums = new List<SelectListItem>();
                enums = JsonConvert.DeserializeObject<List<SelectListItem>>(result);
                vm.Categories = enums;
                ViewBag.category = vm;
            }
            return View();
        }
        public IActionResult AddOrEditProduct(int id = 0)
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Login(string uname, string pass)
        {
            
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"RestaurantLogin/{uname}/{pass}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                if(Convert.ToInt32(result) > 0)
                {
                    HttpContext.Session.SetString("ResId", result);
                    return RedirectToAction("Index");
                }                
            }
            return View();
        }

    }
}
