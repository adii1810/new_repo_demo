using DataAccessLayer;
using Food_Delivery_Api.Repository;
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
    }
}
