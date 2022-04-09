using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using My_Project.Areas.Restaurant.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace My_Project.Areas.Restaurant.Models
{
    public class ImgUpload
    {

        private readonly IConfiguration _config;
        public string RestaurantApiString;
        private readonly IHostingEnvironment _env;
        //=====FireBase========
        private static string apiKey = "AIzaSyBXtJAwAegfHApNAxk0zv4a206QLgZV7_U";
        private static string Bucket = "democoreproject.appspot.com";
        private static string AuthEmail = "dotnetdemo@gmail.com";
        private static string AuthPassword = "dotnet@123";

        public ImgUpload(IHostingEnvironment env, IConfiguration config)
        {
            _env = env;
            _config = config;
            RestaurantApiString = _config.GetValue<string>("RESTAURANTAPISTRING");
        }

        public async Task<string> ImgUpd(IList<IFormFile> item, string sess, string prodid)
        {
            foreach (var i in item)
            {
                ProductImageViewModel pivm = new ProductImageViewModel();
                var file = i;
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
                        var link = upload.TargetUrl;
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri(RestaurantApiString);
                        HttpResponseMessage httpResponse = await client.GetAsync($"imgLink?link={link}&uniqueName={uniqueName}");
                        if (httpResponse.IsSuccessStatusCode)
                        {
                            var result = httpResponse.Content.ReadAsStringAsync().Result;
                            return await upload;
                        }


                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"***************{ex}*************");
                        throw;
                    }
                }
            }
            return null;
        }
    }
}

