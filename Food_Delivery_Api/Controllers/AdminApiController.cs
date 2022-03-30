﻿using DataAccessLayer;
using Food_Delivery_Api.Repository;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Food_Delivery_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly IAdminInterface _admin;

        public AdminApiController(IAdminInterface admin)
        {
            _admin = admin;
        }

        // GET: api/<AdminApiController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value134", "value2" };
        //}


        [HttpGet("Category")]
        public IList<SelectListItem> Category()
        {
            var data = _admin.AutocompleteMainCategory();
            return data;
        }

        [HttpGet("SubCategory")]
        public IEnumerable<SubViewModel> SubCategory(int mainId)
        {
            var data = _admin.AutocompleteSubCategory(mainId);
            return data;
            }

        [HttpGet("ShowProduct")]
        public IEnumerable<ProductRatingViewModel> ShowProduct()
        {
            var data = _admin.ShowProduct();
            return data;
        }

        [HttpGet("ShowProduct/{mainId}/{name}")]
        public IEnumerable<ProductRatingViewModel> ShowProduct(int mainId,string name=null)
        {
            var data = _admin.ShowProduct(mainId,name);
            return data;
        }
        [HttpGet("myR")]
        public IEnumerable<string> myR(string pre)
        {
            var data = _admin.MyRestaurant(pre);
            return data;
        }
        

        [HttpGet("{user,pass}")]
        public string Login(string user,string pass)
        {
            if (user != null && pass != null)
            {
                var data = _admin.AdminLogin(user, pass);
                if (data != 0)
                {
                    return "true";
                }
            }
            return "false";
        }

        [HttpGet("ShowUser")]
        public async Task<IEnumerable<User_Data>> ShowUser()
        {

            var data = await _admin.ShowUser();
            return data;
        }

       

        [HttpGet("ShowOrder/{UserId}")]
        public async Task<IEnumerable<OrderViewModel>> ShowOrder(int UserId)
        {

            var data = await _admin.OrderPerUser(UserId);
            return data;
        }
        [HttpGet("ShowOrderDetails/{OrderId}")]
        public async Task<IEnumerable<OrderDetailViewModel>> ShowOrderDetails(int OrderId)
        { 
            var data = await _admin.OrderDetailsPerUser(OrderId);
            return data;
        }

        
        //[HttpGet("ShowProduct/{MainId,name}")]
        //public IEnumerable<Product> ShowProduct(int MainId, string name)
        //{
        //    var data = _admin.ShowProduct(MainId, name);
        //    return data;
        //}
        //POST api/<AdminApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AdminApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AdminApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
