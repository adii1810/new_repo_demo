using DataAccessLayer;
using Food_Delivery_Api.Repository;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerInterface _Customer;

        public CustomerController(ICustomerInterface customer)
        {
            _Customer = customer;
        }

       
        [HttpPost("AddCustomer")]
        public string AddCustomer(User_Data ud)
        {
            var data = _Customer.AddCustomer(ud);
            return data;
        }
        [HttpGet("LoginCustomer/{Uname}/{Pass}")]
        public async Task<User_Data> LoginCustomer(string Uname, string Pass)
        {
            var data = await _Customer.LoginCustomer(Uname,Pass);
            return data;
        }
        [HttpGet("ShowProduct/{tab}")]
        public async Task<IEnumerable<ProductforCustomerViewModel>> ShowProduct(string tab)
        {
            var data = await _Customer.ShowProduct(tab);
            return data;
        }
    }
}
