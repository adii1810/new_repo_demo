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
using My_Project.Areas.Restaurant.Models;

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
        public RestaurantController(IEmailSender emailSender, IConfiguration config, IHostingEnvironment env)
        {
            _emailSender = emailSender;
            _config = config;
            AdminApiString = _config.GetValue<string>("APISTRING");
            RestaurantApiString = _config.GetValue<string>("RESTAURANTAPISTRING");
            
            _env = env;
        }
        public IActionResult Index()
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString()??"";
            if (sess != "" && sess != null)
                return View();
            else
                return RedirectToAction("Login");

        }
        public async Task<IActionResult> ShowProduct()
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? ""; 
            if (sess != "" && sess != null)
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
            else
                return RedirectToAction("Login");
        }
        public async Task<IEnumerable<ShowProductViewModel>> ShowProduct1()
        {
            var sess = HttpContext.Session.GetString("ResId");
            var resid = Convert.ToInt32(sess);
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(RestaurantApiString);

            HttpResponseMessage httpResponse1 = await client1.GetAsync($"ShowProduct/{resid}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result = httpResponse1.Content.ReadAsStringAsync().Result;
                List<ShowProductViewModel> svm = new List<ShowProductViewModel>();
                svm = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result);
                return svm;
            }
            return null;
        }

        [HttpPost]
        public async Task<IEnumerable<ShowProductViewModel>> ShowProduct1(int Drop, string Name = "")
        {
            if (Name == null)
                Name = "null";

            var sess = HttpContext.Session.GetString("ResId");
            var resid = Convert.ToInt32(sess);
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(RestaurantApiString);

            HttpResponseMessage httpResponse1 = await client1.GetAsync($"ShowProduct/{Drop}/{Name}/{resid}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result = httpResponse1.Content.ReadAsStringAsync().Result;
                List<ShowProductViewModel> svm = new List<ShowProductViewModel>();
                svm = JsonConvert.DeserializeObject<List<ShowProductViewModel>>(result);
                return svm;
            }
            return null;
        }

        public async Task<IActionResult> AddOrEditProduct(int id = 0)
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? ""; 
            if (sess != "" && sess != null)
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
            else
                return RedirectToAction("Login");
        }
        public async Task<IActionResult> EditProduct(int id = 0)
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? ""; 
            if (sess != "" && sess != null)
            {
                ProductViewModel pvm = new ProductViewModel();
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse3 = await client1.GetAsync($"GetProductDetail/{id}");
                if (httpResponse3.IsSuccessStatusCode)
                {
                    var result2 = httpResponse3.Content.ReadAsStringAsync().Result;
                    pvm = JsonConvert.DeserializeObject<ProductViewModel>(result2);
                }
                return View(pvm);
            }
            else
                return RedirectToAction("Login");
        }

        public async Task<IActionResult> EditRestaurant(int id = 0)
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? "";
            if (sess != "" && sess != null)
            {
                RestaurantDetailViewModel rvm = new RestaurantDetailViewModel();
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse3 = await client1.GetAsync($"GetRestaurantDetails/{id}");
                if (httpResponse3.IsSuccessStatusCode)
                {
                    var result2 = httpResponse3.Content.ReadAsStringAsync().Result;
                    rvm = JsonConvert.DeserializeObject<RestaurantDetailViewModel>(result2);
                }
                return View(rvm);
            }
            else
                return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? "";
            if (sess != "" && sess != null)
                return RedirectToAction("Index");
            else
                return View();
        }

        public IActionResult ChangePassword()
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? "";
            if (sess != "" && sess != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("ResId", "");
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> UpdateImages(int Prodid)
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? "";
            if (sess != "" && sess != null)
            {
                List<ImageViewModel> ivm = new List<ImageViewModel>();
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse3 = await client1.GetAsync($"UpdateImage/{Prodid}");
                if (httpResponse3.IsSuccessStatusCode)
                {
                    var result2 = httpResponse3.Content.ReadAsStringAsync().Result;
                    ivm = JsonConvert.DeserializeObject<List<ImageViewModel>>(result2);
                }
                return View(ivm);
            }
            else
                return RedirectToAction("Login");
        }

        public async Task<IActionResult> ApproveOrder()
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? "";
            if (sess != "" && sess != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"GetUnApprovedOrders/{Convert.ToInt32(sess)}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    if (result != "")
                    {
                        List<ShowOrderViewModel> lvm = new List<ShowOrderViewModel>();
                        lvm = JsonConvert.DeserializeObject<List<ShowOrderViewModel>>(result);
                        return View(lvm);
                    }
                }
                return View();
            }
            else
                return RedirectToAction("Login");
        }
        public async Task<IActionResult> ShowOrderDetail(int OrdId)
        {
            var sess = HttpContext.Session.GetString("ResId")?.ToString() ?? "";
            if (sess != "" && sess != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"ShowOrderDetail/{OrdId}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    if (result != "")
                    {
                        List<OrderDetailViewModel> uv = new List<OrderDetailViewModel>();
                        uv = JsonConvert.DeserializeObject<List<OrderDetailViewModel>>(result);
                        return View(uv);
                    }
                }
                return View();
            }
            else
                return RedirectToAction("Login");
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
                if (result != "")
                {
                    RestaurantDetailViewModel uv = new RestaurantDetailViewModel();
                    uv = JsonConvert.DeserializeObject<RestaurantDetailViewModel>(result);
                    if (uv.Restaurant_Detail_Id > 0)
                    {
                        HttpContext.Session.SetString("ResId", uv.Restaurant_Detail_Id.ToString());
                        HttpContext.Session.SetString("ResName", uv.Restaurant_Detail_Name);
                        HttpContext.Session.SetString("ResUserName", uv.Restaurant_Detail_User_Name);
                        HttpContext.Session.SetString("ResImgLink", uv.profileImage);
                        HttpContext.Session.SetString("ResEmail", uv.Restaurant_Detail_Email);
                        var data = HttpContext.Session.GetString("ResId");
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> ChangeStatus(int ProdId, bool status)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ChangeStatus/{ProdId}/{status}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                return Json(result);
            }
            return null;
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
                ViewBag.categories = vm;

                //getting current product Id

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse4 = await client2.GetAsync($"GetCurrentRecordId");
                string prodid = null;
                if (httpResponse4.IsSuccessStatusCode)
                {
                    prodid = httpResponse4.Content.ReadAsStringAsync().Result;
                }

                foreach (var item in pvm.images)
                {
                    // var str =  _Upload.ImgUpd(pvm.images, sess, prodid);
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
                    HttpResponseMessage httpResponse5 = await client3.PostAsJsonAsync($"StoringImage", pivm);
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
                        .Child($"{uniqueName}")
                        .PutAsync(fs, canceation.Token);
                       
                        try
                        {
                            var link = await upload;
                            pivm.link = link;
                            HttpClient client5 = new HttpClient();
                            client5.BaseAddress = new Uri(RestaurantApiString);
                            HttpResponseMessage httpResponse6 = await client5.PutAsJsonAsync($"imgLink/{uniqueName}", pivm);
                            if (httpResponse6.IsSuccessStatusCode)
                            {
                                var result11 = httpResponse6.Content.ReadAsStringAsync().Result;

                            }
                            ViewBag.link = await upload;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"***************{ex}*************");
                            throw;
                        }
                    }
                }
                return LocalRedirect("~/Restaurant/Restaurant/Index");
            }
            return View();


        }

        [HttpPost]
        public async Task<string> DeleteImage(string Id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"DeleteImage/{Id}");
            if (httpResponse.IsSuccessStatusCode)
            {
                return "null";
            }
            return "null";


        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel pvm)
        {
            var sess = HttpContext.Session.GetString("ResId");
            if (sess != null)
            {
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse3 = await client1.PutAsJsonAsync($"EditProduct/{pvm.Product_Id}",pvm);
                if (httpResponse3.IsSuccessStatusCode)
                {
                    return RedirectToAction("ShowProduct");
                }
                return View(pvm);
            }
            else
                return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AddImage(int prodId)
        {
            var sess = HttpContext.Session.GetString("ResId");
            if (sess != "")
            {
                var id = HttpContext.Session.GetString("ResId");
                ProductImageViewModel pvm = new ProductImageViewModel();
                pvm.ProductId = prodId;
                pvm.Restaurant_DetailId = Convert.ToInt32(id);
                return View(pvm);
            }
            else
                return RedirectToAction("Login");

        }
        [HttpPost]
        public async Task<IActionResult> AddImage(ProductImageViewModel p)
        {
            ProductImageViewModel pvm = new ProductImageViewModel();
            foreach (var item in p.images)
            {
                // var str =  _Upload.ImgUpd(pvm.images, sess, prodid);

                var file = item;
                FileStream fs = null;
                string foldername = p.Restaurant_DetailId.ToString();
                var guid = Guid.NewGuid().ToString();
                var uniqueName = guid + '_' + file.FileName;
                pvm.imgName = uniqueName;
                pvm.ProductId = p.ProductId;
                pvm.Restaurant_DetailId = p.Restaurant_DetailId;

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
                    }).Child("assets").Child(p.Restaurant_DetailId.ToString())
                    .Child($"{uniqueName}")
                    .PutAsync(fs, canceation.Token);

                    try
                    {
                        var link = await upload;
                        pvm.link = link;
                        HttpClient client5 = new HttpClient();
                        client5.BaseAddress = new Uri(RestaurantApiString);
                        HttpResponseMessage httpResponse6 = await client5.PutAsJsonAsync($"imgLink/{uniqueName}", pvm);
                        if (httpResponse6.IsSuccessStatusCode)
                        {
                            var result11 = httpResponse6.Content.ReadAsStringAsync().Result;

                        }
                        ViewBag.link = await upload;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"***************{ex}*************");
                        throw;
                    }
                }
            }
            return LocalRedirect($"~/Restaurant/Restaurant/UpdateImages?Prodid={pvm.ProductId}");
        }

        [HttpPost]
        public async Task<JsonResult> myProduct(string Prefix)
        {
            HttpClient client1 = new HttpClient();
            client1.BaseAddress = new Uri(RestaurantApiString);
            var httpResponse1 = await client1.GetAsync($"MyP?pre={Prefix}");
            if (httpResponse1.IsSuccessStatusCode)
            {
                var result1 = httpResponse1.Content.ReadAsStringAsync().Result;
                return Json(result1);
            }
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> EditRestaurant(RestaurantDetailViewModel vm)
        {
            var sess = HttpContext.Session.GetString("ResId");

            if (sess != "" && sess != null)
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
                HttpClient client1 = new HttpClient();
                client1.BaseAddress = new Uri(RestaurantApiString);
                HttpResponseMessage httpResponse3 = await client1.PostAsJsonAsync($"EditRestaurantDetails",vm);
                if (httpResponse3.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("ResId", vm.Restaurant_Detail_Id.ToString());
                    HttpContext.Session.SetString("ResName", vm.Restaurant_Detail_Name);
                    HttpContext.Session.SetString("ResImgLink", vm.profileImage);
                    return RedirectToAction("ShowProduct");
                }
                return View();
            }
            else
                return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<JsonResult> code(string prepass)
        {
            var userName = HttpContext.Session.GetString("ResUserName").ToString();
            var email = HttpContext.Session.GetString("ResEmail").ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"RestaurantConfirmPass/{userName}/{prepass}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                if(Convert.ToInt32(result) > 0)
                {
                    Random r = new Random();
                    int randNum = r.Next(1000000);
                    string sixDigitNumber = randNum.ToString("D6");
                    var MsgBody = sixDigitNumber;
                    var message = new Message(email, "Security Code For Changing Password", MsgBody);
                    _emailSender.SendEmail(message);
                    return Json(sixDigitNumber);
                    
                }
            }
            return Json("false");

        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string pass)
        {
            var userName = HttpContext.Session.GetString("ResUserName").ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ChangePassword/{userName}/{pass}");
            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> ApproveOrder(int OrdId)
        {

            var userName = HttpContext.Session.GetString("ResUserName").ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(RestaurantApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"UpdateOrderStatus/{OrdId}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                if(result != "")
                {
                    return Json("true");
                }
            }
            return Json("false");
        }
    }
}
