using EmailServices;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using My_Project.Areas.Client.ViewModels;
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
        public string RestaurantApiString;
        public ClientController(IEmailSender emailSender, IConfiguration config, IHostingEnvironment env)
        {
            _emailSender = emailSender;
            _config = config;
            RestaurantApiString = _config.GetValue<string>("RESTAURANTAPISTRING");
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
        public IActionResult CustomerLogin()
        {
            return View();
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
                return LocalRedirect("~/Restaurant/Restaurant/Index");
            }
            return RedirectToAction("Index");
        }
    }
}
