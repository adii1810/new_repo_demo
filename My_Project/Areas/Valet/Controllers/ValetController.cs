using EmailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using My_Project.Areas.Admin.ViewModels;
using My_Project.Areas.Valet.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace My_Project.Areas.Valet.Controllers
{
    [Area("Valet")]
    public class ValetController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _config;
        public string ValetApiString;

        public ValetController(IEmailSender emailSender, IConfiguration config)
        {
            _emailSender = emailSender;
            _config = config;
            ValetApiString = _config.GetValue<string>("VALETAPISTRING");
        }
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ValetApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ShowOrder");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;

                List<OrderViewModel> data = new List<OrderViewModel>();
                data = JsonConvert.DeserializeObject<List<OrderViewModel>>(result);
                return View(data);
            }
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(string UserName,string Password)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ValetApiString);
            HttpResponseMessage response = await client.GetAsync($"Login/{UserName}/{Password}");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                if (result != "")
                {
                    ValetViewModel cm = new ValetViewModel();
                    cm = JsonConvert.DeserializeObject<ValetViewModel>(result);
                    HttpContext.Session.SetString("ValetId", cm.Valet_Id.ToString());
                    HttpContext.Session.SetString("ValetName", cm.Valet_Name);
                    //HttpContext.Session.SetString("ResUserName", uv.Restaurant_Detail_User_Name);
                    //HttpContext.Session.SetString("ResImgLink", uv.profileImage);
                    //HttpContext.Session.SetString("ResEmail", uv.Restaurant_Detail_Email);
                    return RedirectToAction("Index");
                }
                else
                    return View();

            }
            return View();
        }
    }
}
