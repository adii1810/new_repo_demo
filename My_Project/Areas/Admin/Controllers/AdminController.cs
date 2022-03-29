using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Project.Areas.Admin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace My_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
       
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
            client.BaseAddress = new Uri("http://localhost:39658");
            HttpResponseMessage httpResponse = await client.GetAsync($"api/Adminapi/ShowUser");
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
            client.BaseAddress = new Uri("http://localhost:39658");
            HttpResponseMessage httpResponse = await client.GetAsync($"api/Adminapi/ShowOrder/{Id}");
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
        public async Task<ActionResult> ShowOrdersDetails(int Id,int total)
        {
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:39658");
            HttpResponseMessage httpResponse = await client.GetAsync($"api/Adminapi/ShowOrderDetails/{Id}");
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
            //// var str = HttpContext.Session.GetString("Admin");
            // if (str != null)
            // {

            CategoryViewModel vm = new CategoryViewModel();
            //var str = HttpContext.Session.GetString("Admin");
            //if (str != null)
            //{
                HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/AdminApi/Category");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    //UserDataViewModel userData = new UserDataViewModel();
                    List<SelectListItem> enums = new List<SelectListItem>();
                    enums = JsonConvert.DeserializeObject<List<SelectListItem>>(result);
                    vm.Categories = enums;

                    ViewBag.category = vm;
                }

            // return RedirectToAction("AdminLogin");

            HttpClient client1 = new HttpClient();
           
            client1.BaseAddress = new Uri("http://localhost:39658");
            var httpResponse1 = await client1.GetAsync($"api/Adminapi/ShowProduct");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                List<ShowProductViewModel> data1 = new List<ShowProductViewModel>();
                data1 = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result1);
                return View(data1);
            }
            return View();
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
        public async Task<ActionResult> ShowProduct(int MyDrop , string restaurant_Name="")
        {
            if (restaurant_Name == null)
                restaurant_Name = "null";
            CategoryViewModel vm = new CategoryViewModel();
            //var str = HttpContext.Session.GetString("Admin");
            //if (str != null)
            //{
                HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri("http://localhost:39658");
                HttpResponseMessage httpResponse = await client.GetAsync($"api/AdminApi/Category");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    //UserDataViewModel userData = new UserDataViewModel();
                    List<SelectListItem> enums = new List<SelectListItem>();
                    enums = JsonConvert.DeserializeObject<List<SelectListItem>>(result);
                    vm.Categories = enums;

                    ViewBag.category = vm;
                }

          
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri("http://localhost:39658");
                var httpResponse1 = await client1.GetAsync($"api/Adminapi/Showproduct/{MyDrop}/{restaurant_Name}");
                if (httpResponse1.IsSuccessStatusCode)
                {
                    var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                    //UserDataViewModel userData = new UserDataViewModel();
                    List<ShowProductViewModel> data1 = new List<ShowProductViewModel>();
                    data1 = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result1);
                    return View(data1);
                }
            
            return View();  
        }

        [HttpPost]
        public async Task<JsonResult> myResturant(string Prefix)
        {
            HttpClient client1 = new HttpClient();

            client1.BaseAddress = new Uri("http://localhost:39658");
            var httpResponse1 = await client1.GetAsync($"api/Adminapi/MyR?pre={Prefix}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                //UserDataViewModel userData = new UserDataViewModel();
                //List<restaurantNameViewModel> data1 = new List<restaurantNameViewModel>();
                //data1 = JsonConvert.DeserializeObject<List<restaurantNameViewModel>>(result1);
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
