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

        // GET: AdminController
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public async Task<ActionResult> ShowUser()
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ShowUser");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<UserDataViewModel> data = new List<UserDataViewModel>();
                data = JsonConvert.DeserializeObject<List<UserDataViewModel>>(result);
                return View(data);
            }
            return View();
            //  }
        }

        public async Task<ActionResult> ShowOrders(int Id)
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ShowOrder/{Id}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<OrderViewModel> data = new List<OrderViewModel>();
                data = JsonConvert.DeserializeObject<List<OrderViewModel>>(result);
                return View(data);
            }
            return View();
            //  }
        }
        public async Task<ActionResult> ShowOrdersDetails(int Id, int total)
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(AdminApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ShowOrderDetails/{Id}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<OrderDetailViewModel> data = new List<OrderDetailViewModel>();
                data = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(result);
                ViewBag.total = total;
                return View(data);
            }
            return View();
            //  }
        }

        public async Task<ActionResult> ShowProduct()
        {
            CategoryViewModel vm = new CategoryViewModel();
            //var str = HttpContext.Session.GetString("Admin");
            //if (str != null)
            //{
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
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {


            //var str = HttpContext.Session.GetString("Admin");
            //if (str != null)
            //{

            //  }
            return View();
        }

        public async Task<IEnumerable<ShowProductViewModel>> ShowProduct1()
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {x
            // return RedirectToAction("AdminLogin");

            HttpClient client1 = new HttpClient();

            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"ShowProduct");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<ShowProductViewModel> data1 = new List<ShowProductViewModel>();
                data1 = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result1);
                return data1;
            }
            return null;
            //  }
        }

        public async Task<ActionResult> ShowRestaurant()
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {x
            // return RedirectToAction("AdminLogin");

           
            return View();
            //  }
        }
        [HttpGet]
        public async Task<IEnumerable<RestaurantViewModel>> ShowRestaurant1()
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {x
            // return RedirectToAction("AdminLogin");

            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"ShowRestaurant");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<RestaurantViewModel> data1 = new List<RestaurantViewModel>();
                data1 = JsonConvert.DeserializeObject<List<RestaurantViewModel>>(result1);
                return data1;
            }
            return null;
            //  }
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
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
        public async Task<JsonResult> updateStatus(int Id,bool Status,string Email)
        {
         
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(AdminApiString);
            var httpResponse1 = await client1.GetAsync($"updateStatus/{Id}/{Status}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                var MsgBody = Status == true ? "<p class='text-danger'>Account Has Been Activated</p>" : "<p class='text-danger'>Account Has Been Dectivated</p>";
                var message = new Message(Email, "No Reply",MsgBody);
                _emailSender.SendEmail(message);
                return Json(result1);
            }
            return null;
        }
        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
