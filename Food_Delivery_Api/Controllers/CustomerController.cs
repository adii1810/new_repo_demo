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

        [HttpGet("ViewProductCart/{userId}")]
        public IEnumerable<CartProductViewModel> ViewProductCart (int userId)
        {
            var data =  _Customer.ViewProductCart(userId);
            return data;
        }

        [HttpGet("deleteProduct/{ProdId}/{userId}")]
        public string deleteProduct(int ProdId, int userId)
        {
            var result = _Customer.deleteProduct(ProdId, userId);
            return result;
        }
        [HttpGet("IncrementDecrement/{status}/{prodId}/{userId}")]
        public string IncrementDecrement(string status, int prodId, int userId)
        {
            var result = _Customer.IncrementDecrement(status, prodId, userId);
            return result;
        }
        [HttpGet("CheckOut/{userId}")]
        public string CheckOut(int userId)
        {
            var result = _Customer.CheckOut(userId);
            return result;
        }
        [HttpGet("ShowOrder/{userId}")]
        public IEnumerable<ShowOrderViewModel> ShowOrder(int userId)
        {
            var result = _Customer.ShowOrder(userId);
            return result;
        }
        [HttpPost("AddProductCart")]
        public string AddProductCart(CartProductViewModel vm)
        {
            var data =  _Customer.AddProductCart(vm);
            return data;
        }
        [HttpGet("ShowOrderDetail/{userId}/{ordId}")]
        public IEnumerable<CartProductViewModel> ShowOrderDetail(int userId,int ordId)
        {
            var data = _Customer.ShowOrderDetail(userId,ordId);
            return data;
        }
        [HttpGet("ShowRestaurant")]
        public IEnumerable<Restaurant_Detail> ShowRestaurant()
        {
            var result = _Customer.ShowRestaurant();
            return result;
        }
    }
}
