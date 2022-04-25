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
          
            var valetId = HttpContext.Session.GetString("ValetId")?.ToString() ?? "";
            if (valetId != "" && valetId != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ValetApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"ShowOrder");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;

                    List<OrderViewForValet> data = new List<OrderViewForValet>();
                    data = JsonConvert.DeserializeObject<List<OrderViewForValet>>(result);
                    return View(data);
                }
                return View();
            }
            else
                return RedirectToAction("Login");
        }
        public async Task<JsonResult> ApproveOrders(int OrdId)
        {
            var valetId = HttpContext.Session.GetString("ValetId")?.ToString() ?? "";
           
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ValetApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"ApproveOrders/{OrdId}/{Convert.ToInt32(valetId)}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    if (result != "")
                    {
                        return Json(result);
                    }
                }
                return Json("false");
            
        }
        public async Task<IActionResult> ApprovedOrders()
        {
            var valetId = HttpContext.Session.GetString("ValetId")?.ToString() ?? "";
            if (valetId != "" && valetId != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ValetApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"ApprovedOrders/{Convert.ToInt32(valetId)}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;

                    List<OrderViewForValet> data = new List<OrderViewForValet>();
                    data = JsonConvert.DeserializeObject<List<OrderViewForValet>>(result);
                    return View(data);
                }
                return View();
            }
            else
                return RedirectToAction("Login");
        }
        public async Task<ActionResult> ShowOrdersDetails(int Id)
        {
            var valetId = HttpContext.Session.GetString("ValetId")?.ToString() ?? "";
            if (valetId != "" && valetId != null)
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(ValetApiString);
                HttpResponseMessage httpResponse = await client.GetAsync($"ShowOrderDetails/{Id}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    List<OrderDetailForValet> data = new List<OrderDetailForValet>();
                    data = JsonConvert.DeserializeObject<List<OrderDetailForValet>>(result);
                    return View(data);
                }
                return View();
            }
            else
                return RedirectToAction("Login");
        }
        public IActionResult ChangePassword()
        {
            var valetId = HttpContext.Session.GetString("ValetId")?.ToString() ?? "";
            if (valetId != "" && valetId != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public IActionResult Login()
        {
            var valetId = HttpContext.Session.GetString("ValetId")?.ToString()??"";
            if (valetId != "" && valetId != null)
            {
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("ValetId", "");
            return RedirectToAction("Login");
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
                    HttpContext.Session.SetString("ValUserName", cm.Valet_UserName);
                    //HttpContext.Session.SetString("ResImgLink", uv.profileImage);
                    HttpContext.Session.SetString("ValEmail", cm.Valet_Email);
                    return RedirectToAction("Index");
                }
                else
                    return View();

            }
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> ChangeStatus(int OrdId,int Status)
        {
            var valetId = Convert.ToInt32(HttpContext.Session.GetString("ValetId").ToString());
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ValetApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ChangeStatus/{OrdId}/{Status}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                if(result != "")
                {
                    return Json(result);
                }
            }
            return Json("false");
        }
        [HttpPost]
        public async Task<JsonResult> code(string prepass)
        {
            var userName = HttpContext.Session.GetString("ValUserName").ToString();
            var email = HttpContext.Session.GetString("ValEmail").ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ValetApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ValetConfirmPass/{userName}/{prepass}");
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = httpResponse.Content.ReadAsStringAsync().Result;
                if (Convert.ToInt32(result) > 0)
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
            var userName = HttpContext.Session.GetString("ValUserName").ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(ValetApiString);
            HttpResponseMessage httpResponse = await client.GetAsync($"ChangePassword/{userName}/{pass}");
            if (httpResponse.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
