using DataAccessLayer;
using Food_Delivery_Api.Repository;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValetController : ControllerBase
    {
        private readonly IValetInterface _valet;
        EncryptionDecryption END = new EncryptionDecryption();

        public ValetController(IValetInterface valet)
        {
            _valet = valet;
        }
        [HttpGet("Login/{user}/{pass}")]
        public Valet Login(string user, string pass)
        {
            pass = END.Encryption(pass);
            if (user != null && pass != null)
            {
                var data = _valet.ValetLogin(user, pass);
                if (data != null)
                {
                    return data;
                }
            }
            return null;
        }
        [HttpGet("ShowOrder")]
        public async Task<IEnumerable<OrderViewForValet>> ShowOrder()
        {

            var data = _valet.ShowOrder();
            if (data != null)
            {
                return data;
            }
            return null;
        }
        [HttpGet("ShowOrderDetails/{OrdId}")]
        public async Task<IEnumerable<OrderDetailForValet>> ShowOrderDetails(int OrdId)
        {
            var data = _valet.ShowOrderDetails(OrdId);
            if (data != null)
            {
                return data;
            }
            return null;
        }
        [HttpGet("ApprovedOrders/{valId}")]
        public async Task<IEnumerable<OrderViewForValet>> ApprovedOrders(int valId)
        {

            var data = _valet.ApprovedOrders(valId);
            if (data != null)
            {
                return data;
            }
            return null;
        }
       
        [HttpPut("ApproveOrders/{OrdId}")]
        public string ApproveOrders(int OrdId,[FromBody] int valId)
        {
            var result = _valet.ApproveOrder(OrdId, valId);
            return result;
        }
       
        [HttpPut("ChangePassword/{uname}")]
        public string ChangePassword(string uname,[FromBody] string pass)
        {
            pass = END.Encryption(pass);
            var data = _valet.ChangePassword(uname, pass);
            return data;
        }

        [HttpGet("ValetConfirmPass/{username}/{password}")]
        public async Task<int> ValetConfirmPass(string username, string password)
        {
            password = END.Encryption(password);
            var data = _valet.ValetConfirmPassword(username, password);
            return data;
        }
        [HttpGet("GetValet/{ValId}")]
        public Valet GetUser(int ValId)
        {
            var result = _valet.GetValet(ValId);
            return result;
        }
        [HttpGet("ResetPassword/{Username}/{Email}")]
        public async Task<int> ResetPassword(string Username, string Email)
        {
            var data = _valet.verifyAccount(Username, Email);
            return data;
        }
        [HttpPost("ValetReg")]
        public String ValetReg(Valet val)
        {
            val.Valet_Password = END.Encryption(val.Valet_Password);
            if (val != null)
            {
                var data = _valet.ValetReg(val);
                if (data != "" && data != "false")
                {
                    return data;
                }
            }
            return "false";
        }
        [HttpPut("ChangeStatus/{OrdId}")]
        public string ChangeStatus(int OrdId, [FromBody] int status)
        {
            var result = _valet.ChangeStatus(OrdId, status);
            return result;
        }
        [HttpPut("UpdateValet")]
        public string UpdateValet(Valet vm)
        {
            var result = _valet.UpdateValet(vm);
            return result;
        }
       
        [HttpPut("ResetPassword/{Username}/{Email}")]
        public async Task<string> ResetPassword(string Username, string Email, [FromBody] string Pass)
        {
            Pass = END.Encryption(Pass);
            var data = _valet.ChangePassword(Username, Pass);
            return data;
        }
    }
}
