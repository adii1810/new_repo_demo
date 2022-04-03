using EmailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Project.Areas.Admin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace My_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;
        public string AdminApiString;

        public AdminController(IEmailSender emailSender,IConfiguration config)
        {
            _emailSender = emailSender;
            _config = config;
            AdminApiString =  _config.GetValue<string>("APISTRING");
        }

        public async Task<ActionResult> AdminLogin()
        {
            return View();
        }
        public async Task<ActionResult> ShowUser()
        {
            var str = HttpContext.Session.GetString("Admin");

            if (str == "Admin")
            {
                return View();
            }
            return RedirectToAction("AdminLogin","Admin");
        }
        
        [HttpGet]
        public async Task<IEnumerable<UserDataViewModel>> ShowUser1()
        {
           
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(AdminApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"ShowUser");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    List<UserDataViewModel> data = new List<UserDataViewModel>();
                    data = JsonConvert.DeserializeObject<List<UserDataViewModel>>(result);
                    return data;
                }
                return null;
            
        }

        public async Task<ActionResult> ShowOrders(int Id)
        {
            var str = HttpContext.Session.GetString("Admin");

            if (str == "Admin")
            {           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ShowOrder/{Id}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;

                List<OrderViewModel> data = new List<OrderViewModel>();
                data = JsonConvert.DeserializeObject<List<OrderViewModel>>(result);
                return View(data);
            }
            return View();
            }
            return RedirectToAction("AdminLogin");
        }

        public async Task<ActionResult> ShowOrdersDetails(int Id, int total)
        {
            var str = HttpContext.Session.GetString("Admin");

            if (str == "Admin")
            {

                HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ShowOrderDetails/{Id}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                List<OrderDetailViewModel> data = new List<OrderDetailViewModel>();
                data = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(result);
                ViewBag.total = total;
                return View(data);
            }
            return View();
            }
            return RedirectToAction("AdminLogin");
        }

        public async Task<ActionResult> ShowProduct()
        {
            var str = HttpContext.Session.GetString("Admin");

            if (str == "Admin")
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
            return RedirectToAction("AdminLogin");
        }

        public async Task<IEnumerable<ShowProductViewModel>> ShowProduct1()
        {
            HttpClient client1 = new HttpClient();

            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"ShowProduct");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                List<ShowProductViewModel> data1 = new List<ShowProductViewModel>();
                data1 = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result1);
                return data1;
            }
            return null;
        }

        public ActionResult ShowRestaurant()
        {
            var str = HttpContext.Session.GetString("Admin");

            if (str == "Admin")
            {
                return View();
            }
            return RedirectToAction("AdminLogin");
        }
        [HttpGet]
        public async Task<IEnumerable<RestaurantViewModel>> ShowRestaurant1()
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"ShowRestaurant");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                List<RestaurantViewModel> data1 = new List<RestaurantViewModel>();
                data1 = JsonConvert.DeserializeObject<List<RestaurantViewModel>>(result1);
                return data1;
            }
            return null;
        }

        [HttpPost]
        public async Task<ActionResult> AdminLogin(string User, string Pass)
        {
            var str = HttpContext.Session.GetString("Admin");
            if (str == null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/Adminapi/Login?user={User}&pass={Pass}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    if (result == "true")
                    {
                        HttpContext.Session.SetString("Admin", User);
                        return RedirectToAction("Index");

                    }
                }
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IEnumerable<ShowProductViewModel>> ShowProduct1(int Drop, string Name = "")
        {
            if (Name == null)
                Name = "null";

            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"Showproduct/{Drop}/{Name}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                
                List<ShowProductViewModel> data1 = new List<ShowProductViewModel>();
                data1 = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result1);
                return data1;
            }
            return null;
        }

        [HttpPost]
        public async Task<JsonResult> myResturant(string Prefix)
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"MyR?pre={Prefix}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                return Json(result1);
            }
            return null;
        }
        [HttpPost]
        public async Task<JsonResult> myUser(string Prefix)
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"MyU?pre={Prefix}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                return Json(result1);
            }
            return null;
        }

        [HttpPost]
        public async Task<JsonResult> updateStatus(int Id,bool Status,string Email)
        {
         
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"updateStatus/{Id}/{Status}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                var MsgBody = Status == true ? "Account Has Been Activated" : "Account Has Been Dectivated";
                var message = new Message(Email, "No Reply",MsgBody);
                _emailSender.SendEmail(message);
                return Json(result1);
            }
            return null;
        }
        [HttpPost]
        public async Task<IEnumerable<UserDataViewModel>> FindUser(string Name)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ShowUser1/{Name}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                List<UserDataViewModel> data = new List<UserDataViewModel>();
                data = JsonConvert.DeserializeObject<List<UserDataViewModel>>(result);
                return data;
            }
            return null;
        }         
    }
}
