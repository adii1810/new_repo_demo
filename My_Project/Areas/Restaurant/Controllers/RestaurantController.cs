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
using My_Project.Areas.Restaurant.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Firebase.Auth;
using System.Threading;
using Firebase.Storage;
using System.Diagnostics;

namespace My_Project.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly IHostingEnvironment _env;
        //=====FireBase========
        private static string apiKey = "AIzaSyBXtJAwAegfHApNAxk0zv4a206QLgZV7_U";
        private static string Bucket = "democoreproject.appspot.com";
        private static string AuthEmail = "dotnetdemo@gmail.com";
        private static string AuthPassword = "dotnet@123";



        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;
        public string AdminApiString;
        public string RestaurantApiString;
        public RestaurantController(IEmailSender emailSender, IConfiguration config ,IHostingEnvironment env)
        {
            _emailSender = emailSender;
            _config = config;
            AdminApiString = _config.GetValue<string>("APISTRING");
            RestaurantApiString = _config.GetValue<string>("RESTAURANTAPISTRING");
            _env = env;
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
        public async Task<IActionResult> AddOrEditProduct(int id = 0)
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
               // ViewBag.category = vm;
            }
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse1 = await client1.GetAsync($"FoodType");
            HttpResponseMessage httpResponse2 = await client1.GetAsync($"SubCategory");

            

            if (httpResponse1.IsSuccessStatusCode && httpResponse2.IsSuccessStatusCode)
            {
                var result = httpResponse1.Content.ReadAsStringAsync().Result;
                var result1 = httpResponse2.Content.ReadAsStringAsync().Result;
                List<SelectListItem> subEnums = new List<SelectListItem>();
                List<SubCategoyViewModel> subCategory = new List<SubCategoyViewModel>();
                subEnums = JsonConvert.DeserializeObject<List<SelectListItem>>(result);
                subCategory = JsonConvert.DeserializeObject<List<SubCategoyViewModel>>(result1);
                vm.FoodType = subEnums;
                ViewBag.subCategory = subCategory;
            }
            ViewBag.categories = vm;
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
                    var data = HttpContext.Session.GetString("ResId");
                    return RedirectToAction("Index");
                }                
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOrEditProduct(ProductViewModel pvm)
        {
            var sess = HttpContext.Session.GetString("ResId");
            pvm.Restaurant_Detail = Convert.ToInt32(sess);

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
                // ViewBag.category = vm;
            }
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse1 = await client1.GetAsync($"FoodType");
            HttpResponseMessage httpResponse2 = await client1.GetAsync($"SubCategory");
            HttpResponseMessage httpResponse3 = await client1.PostAsJsonAsync($"AddProduct", pvm);


            if (httpResponse1.IsSuccessStatusCode && httpResponse2.IsSuccessStatusCode && httpResponse3.IsSuccessStatusCode)
            {
                var result = httpResponse1.Content.ReadAsStringAsync().Result;
                var result1 = httpResponse2.Content.ReadAsStringAsync().Result;
                var result3 = httpResponse3.Content.ReadAsStringAsync().Result;

                List<SelectListItem> subEnums = new List<SelectListItem>();
                List<SubCategoyViewModel> subCategory = new List<SubCategoyViewModel>();
                subEnums = JsonConvert.DeserializeObject<List<SelectListItem>>(result);
                subCategory = JsonConvert.DeserializeObject<List<SubCategoyViewModel>>(result1);
                vm.FoodType = subEnums;
                ViewBag.subCategory = subCategory;

                
            }
            ViewBag.categories = vm;

            //getting current product Id
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse4 = await client2.GetAsync($"GetCurrentRecordId");
            string prodid = null;
            if (httpResponse4.IsSuccessStatusCode )
            {
                 prodid = httpResponse4.Content.ReadAsStringAsync().Result;                
                
               
            }

            foreach (var item in pvm.images)
            {
                ProductImageViewModel pivm = new ProductImageViewModel();
                var file = item;
                FileStream fs = null;
                string foldername = sess;
                var guid = Guid.NewGuid().ToString();
                var uniqueName = guid + '_' + file.FileName;
                pivm.imgName = uniqueName;
                pivm.ProductId = Convert.ToInt32(prodid);
                pivm.Restaurant_DetailId = Convert.ToInt32(sess);
                
                HttpClient client3 = new HttpClient();
                client3.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse5 = await client3.PostAsJsonAsync($"StoringImage", pvm);
                if (httpResponse5.IsSuccessStatusCode)
                {
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
                    }).Child("assets").Child(sess)
                    .Child($"{file.FileName}.{Path.GetExtension(file.FileName).Substring(1)}")
                    .PutAsync(fs, canceation.Token);

                    try
                    {
                        ViewBag.link = await upload;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"***************{ex}*************");
                        throw;
                    }
                }
            }
           
            return View();

          
        }
    }
}
