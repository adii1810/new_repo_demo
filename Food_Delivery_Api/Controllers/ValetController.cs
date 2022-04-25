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
        public ValetController(IValetInterface valet)
        {
            _valet = valet;
        }
        [HttpGet("Login/{user}/{pass}")]
        public Valet Login(string user, string pass)
        {
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
        [HttpPost("ValetReg")]
        public String ValetReg(Valet val)
        {
            if (val != null)
            {
                var data = _valet.ValetReg(val);
                if (data != ""&& data != "false")
                {
                    return data;
                }
            }
            return "false";
        }
        [HttpGet("ApproveOrders/{OrdId}/{valId}")]
        public string ApproveOrders(int OrdId, int valId)
        {
            var result = _valet.ApproveOrder(OrdId, valId);
            return result;
        }
        [HttpGet("ChangeStatus/{OrdId}/{status}")]
        public string ChangeStatus(int OrdId, int status)
        {
            var result = _valet.ChangeStatus(OrdId, status);
            return result;
        }
        [HttpGet("ChangePassword/{uname}/{pass}")]
        public string ChangePassword(string uname, string pass)
        {
            var data = _valet.ChangePassword(uname, pass);
            return data;
        }

        [HttpGet("ValetConfirmPass/{username}/{password}")]
        public async Task<int> ValetConfirmPass(string username, string password)
        {
            var data = _valet.ValetConfirmPassword(username, password);
            return data;
        }
    }
}
