using EmailServices;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using My_Project.Areas.Client.ViewModels;
using My_Project.Areas.Valet.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace My_Project.Controllers
{
    [Area("Client")]
    public class ClientController : Controller
    {

        //===============firebase===============
        private static string apiKey = "AIzaSyBXtJAwAegfHApNAxk0zv4a206QLgZV7_U";
        private static string Bucket = "democoreproject.appspot.com";
        private static string AuthEmail = "dotnetdemo@gmail.com";
        private static string AuthPassword = "dotnet@123";
        //===============firebase===============

        private readonly IHostingEnvironment _env;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;
        public string CustomerApiString;
        public string RestaurantApiString;
        public string ValetApiString;
        public ClientController(IEmailSender emailSender, IConfiguration config, IHostingEnvironment env)
        {
            _emailSender = emailSender;
            _config = config;
            CustomerApiString = _config.GetValue<string>("CUSTOMERAPISTRING");
            RestaurantApiString = _config.GetValue<string>("RESTAURANTAPISTRING");
            ValetApiString = _config.GetValue<string>("VALETAPISTRING");
            _env = env;
        }

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult VendorReg()
        {
            return View();
        }
        public IActionResult CustomerReg()
        {
            return View();
        }
        public IActionResult ValetReg()
        {
            return View();
        }
        public IActionResult CustomerLogin()
        {
            ViewBag.IsRegistered = "";
            return View();
        }
        public async Task<IActionResult> CustomerIndex()
        {
            var userId = HttpContext.Session.GetString("UserId")?.ToString()??"";
            if (userId != "")
                return View();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> ShowOrders()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId").ToString());
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"ShowOrder/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<ShowOrderViewModel> lvm = new List<ShowOrderViewModel>();
                if (result != "" && result != null)
                {
                    lvm = JsonConvert.DeserializeObject<List<ShowOrderViewModel>>(result);
                    return View(lvm);
                }
            }
            return View();
        }

        public async Task<IActionResult> Categories()
        {

            return View();
        }
        //For showing cart data
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"ViewProductCart/{Convert.ToInt32(HttpContext.Session.GetString("UserId").ToString())}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != "" && result != null)
                {
                    List<CartProductViewModel> vm = new List<CartProductViewModel>();
                    vm = JsonConvert.DeserializeObject<List<CartProductViewModel>>(result);
                    return PartialView(vm);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ShowOrderDetail(int id)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId").ToString());
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"ShowOrderDetail/{userId}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != "" && result != null)
                {
                    List<CartProductViewModel> vm = new List<CartProductViewModel>();
                    vm = JsonConvert.DeserializeObject<List<CartProductViewModel>>(result);
                    return PartialView(vm);
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.SetString("UserId","");
            HttpContext.Session.SetString("UserName","");
            return RedirectToAction("Index");
        }
        //Adding products to cart
        public async Task<JsonResult> AddProductCart(int prodId)
        {
            var userId = HttpContext.Session.GetString("UserId")?.ToString()??"";
            if (userId != "")
            {
                CartProductViewModel vm = new CartProductViewModel();
                vm.Order_Date = DateTime.Now.Date;
                vm.ProductId = prodId;
                vm.Quantity = 1;
                vm.User_DataId = Convert.ToInt32(HttpContext.Session.GetString("UserId").ToString());

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(CustomerApiString);
                HttpResponseMessage response = await client.PostAsJsonAsync("AddProductCart", vm);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    if (result != "" && result != null)
                        return Json(result);
                }

                return Json("false");
            }
            else
                return Json("Login");
        }
        public async Task<IEnumerable<ShowProductViewModel>> ShowProduct(string Tab)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"ShowProduct/{Tab}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<ShowProductViewModel> vm = new List<ShowProductViewModel>();
                vm = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result);
                return vm;
            }
            return null;
        }
        public async Task<IEnumerable<RestaurantDetailViewModel>> ShowRestaurant()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"ShowRestaurant");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<RestaurantDetailViewModel> vm = new List<RestaurantDetailViewModel>();
                vm = JsonConvert.DeserializeObject<List<RestaurantDetailViewModel>>(result);
                return vm;
            }
            return null;
        }
        public async Task<ActionResult> ShowRestaurantProduct(string ResName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"ShowRestaurantProducts/{ResName}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                List<ShowProductViewModel> vm = new List<ShowProductViewModel>();
                vm = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result);
                ViewBag.ResName = ResName;
                return View(vm);
            }
            return View();
        }

        public async Task<ActionResult> Rating(int ProdId)
        {
            var userId = HttpContext.Session.GetString("UserId")?.ToString() ?? "";
           
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"ViewRating/{Convert.ToInt32(userId)}/{ProdId}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                ViewBag.ProdId = ProdId;
                ViewBag.Rate = Convert.ToInt32(result);
            }
            return View();
        }

        public async Task<ActionResult> UpdateCustomer()
        {
            var userId = HttpContext.Session.GetString("UserId")?.ToString() ?? "";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"GetUser/{Convert.ToInt32(userId)}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                CustomerViewModel cvm = new CustomerViewModel();
                cvm = JsonConvert.DeserializeObject<CustomerViewModel>(result);
                return View(cvm);
            }
            return View();
        }
        public async Task<ActionResult> ChangePassword()
        {
            var userId = HttpContext.Session.GetString("UserId")?.ToString() ?? "";
            if(userId != "")
            {
                return View();
            }
            return RedirectToAction("Index");
          
           
        }
        [HttpPost]
        public async Task<IActionResult> VendorReg(RestaurantDetailViewModel vm)
        {
            var file = vm.img;
            FileStream fs = null;
            string foldername = "RestaurantProfileImage";
            var guid = Guid.NewGuid().ToString();
            var uniqueName = guid + '_' + file.FileName;
            string path = Path.Combine(_env.WebRootPath, $"images/{foldername}");
            if (Directory.Exists(path))
            {
                using (fs = new FileStream(Path.Combine(path, uniqueName), FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                fs = new FileStream(Path.Combine(path, uniqueName), FileMode.Open);
            }
            else
            {
                Directory.CreateDirectory(path);
                using (fs = new FileStream(Path.Combine(path, uniqueName), FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                fs = new FileStream(Path.Combine(path, uniqueName), FileMode.Open);
            }
            //FireBase Uploading
            var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            //Cancelation token
            var canceation = new CancellationTokenSource();
            var upload = new FirebaseStorage(Bucket, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                ThrowOnCancel = true
            }).Child("assets").Child(foldername)
            .Child($"{uniqueName}")
            .PutAsync(fs, canceation.Token);

            try
            {
                var link = await upload;
                vm.profileImage = link;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"***************{ex}*************");
                throw;
            }

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage response = await client.PostAsJsonAsync("AddRestaurant", vm);
            if (response.IsSuccessStatusCode)
            {
                var message = new Message(vm.Restaurant_Detail_Email, "No Reply", "Please wait till Admin Activate Your Account");
                _emailSender.SendEmail(message);
                return LocalRedirect("~/Restaurant/Restaurant/Index");
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> CustomerReg(CustomerViewModel cvm)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.PostAsJsonAsync("AddCustomer", cvm);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != "false")
                {
                    HttpContext.Session.SetString("IsRegistered", "true");
                    return RedirectToAction("Index");
                }
            }
            HttpContext.Session.SetString("IsRegistered", "false");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<JsonResult> CustomerLogin(string Uname, string Pass)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"LoginCustomer/{Uname}/{Pass}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != "")
                {
                    CustomerViewModel cm = new CustomerViewModel();
                    cm = JsonConvert.DeserializeObject<CustomerViewModel>(result);
                    HttpContext.Session.SetString("UserId", cm.User_Id.ToString());
                    HttpContext.Session.SetString("UserName", cm.User_UserName);
                    HttpContext.Session.SetString("UserEmail", cm.User_Email);
                    //HttpContext.Session.SetString("ResImgLink", uv.profileImage);
                    //HttpContext.Session.SetString("ResEmail", uv.Restaurant_Detail_Email);

                    return Json(result);
                }
                else
                    return Json(result);

            }
            return Json("");
        }

        [HttpPost]
        public async Task<JsonResult> IncrementDecrement(string status, int prodId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId").ToString());
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"IncrementDecrement/{status}/{prodId}/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result == "true")
                {
                    return Json(result);
                }
            }
            return Json("false");
        }
        [HttpPost]
        public async Task<JsonResult> deleteProduct(int ProdId)
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId").ToString());
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"deleteProduct/{ProdId}/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != "")
                {
                    return Json(result);
                }
            }
            return Json("false");
        }


        [HttpPost]
        public async Task<JsonResult> CheckOut()
        {
            var userId = Convert.ToInt32(HttpContext.Session.GetString("UserId").ToString());
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"CheckOut/{userId}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != "")
                {
                    return Json(result);
                }
            }
            return Json("false");
        }

        [HttpPost]
        public async Task<IActionResult> ValetReg(ValetViewModel vm)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ValetApiString);
            HttpResponseMessage response = await client.PostAsJsonAsync("ValetReg", vm);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if(result != "")
                {
                    return LocalRedirect("~/Valet/Valet/Login");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<JsonResult> myResturant(string Prefix)
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(CustomerApiString);
            var httpResponse1 = await client1.GetAsync($"MyR?pre={Prefix}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                return Json(result1);
            }
            return null;
        }
        [HttpPost]
        public async Task<JsonResult> Rating(int ProdId,int rate)
        {
            var userId = HttpContext.Session.GetString("UserId")?.ToString() ?? "";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.GetAsync($"AddRating/{Convert.ToInt32(userId)}/{ProdId}/{rate}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                ViewBag.ProdId = ProdId;
                ViewBag.Rate = rate;
                return Json(result);
            }
            return Json("false");
        }
        [HttpPost]
        public async Task<ActionResult> UpdateCustomer(CustomerViewModel cvm)
        {
            var userId = HttpContext.Session.GetString("UserId")?.ToString() ?? "";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage response = await client.PutAsJsonAsync($"UpdateUser",cvm);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if(result == "true")
                {
                    return RedirectToAction("CustomerIndex");
                }
            }
            return RedirectToAction("CustomerIndex");
        }
        [HttpPost]
        public async Task<JsonResult> code(string prepass)
        {
            var userName = HttpContext.Session.GetString("UserName").ToString();
            var email = HttpContext.Session.GetString("UserEmail").ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"UserConfirmPass/{userName}/{prepass}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                if (Convert.ToInt32(result) > 0)
                {
                    Random r = new Random();
                    int randNum = r.Next(1000000);
                    string sixDigitNumber = randNum.ToString("D6");
                    var MsgBody = sixDigitNumber;
                    var message = new Message(email, "Security Code For Your Change Password Request", MsgBody);
                    _emailSender.SendEmail(message);
                    return Json(sixDigitNumber);

                }
            }
            return Json("false");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string pass)
        {
            var userName = HttpContext.Session.GetString("UserName").ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(CustomerApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ChangePassword/{userName}/{pass}");
            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerIndex");
            }
            return RedirectToAction("CustomerIndex");
        }
    }
}
