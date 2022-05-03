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

        [HttpGet("myR")]
        public IEnumerable<string> myR(string pre)
        {
            var data = _Customer.MyRestaurant(pre);
            return data;
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
        [HttpGet("ShowRestaurantProducts/{ResName}")]
        public IEnumerable<ProductforCustomerViewModel> ShowRestaurantProducts(string ResName)
        {
            var result = _Customer.ShowRestaurantProduct(ResName);
            return result;
        }
        [HttpGet("ViewRating/{userId}/{ProdId}")]
        public int ViewRating(int userId,int ProdId)
        {
            var result = _Customer.ViewRating(userId,ProdId);
            return result;
        }
        [HttpGet("AddRating/{userId}/{ProdId}/{rate}")]
        public string AddRating(int userId, int ProdId,int rate)
        {
            var result = _Customer.AddRating(userId, ProdId,rate);
            return result;
        }
        [HttpGet("GetUser/{userId}")]
        public User_Data GetUser(int userId)
        {
            var result = _Customer.GetUser(userId);
            return result;
        }

        [HttpGet("ChangePassword/{uname}/{pass}")]
        public string ChangePassword(string uname, string pass)
        {
            var data = _Customer.ChangePassword(uname, pass);
            return data;
        }

        [HttpGet("UserConfirmPass/{username}/{password}")]
        public async Task<int> UserConfirmPass(string username, string password)
        {
            var data = _Customer.UserConfirmPassword(username, password);
            return data;
        }
        [HttpGet("ResetPassword/{Username}/{Email}")]
        public async Task<int> ResetPassword(string Username, string Email)
        {
            var data = _Customer.verifyAccount(Username, Email);
            return data;
        }

        [HttpPut("ChangePassword/{Username}/{Email}")]
        public async Task<string> ChangePassword(string Username, string Email,[FromBody]string Pass)
        {
            var data = _Customer.ChangePassword(Username, Pass);
            return data;
        }

        [HttpPut("UpdateUser")]
        public string UpdateUser(User_Data vm)
        {
            var result = _Customer.UpdateUser(vm);
            return result;
        }

    }
}
