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

        [HttpGet("Category")]
        public IList<SelectListItem> Category()
        {
            var data = _admin.AutocompleteMainCategory();
            return data;
        }

        [HttpGet("SubCategory/{mainId}")]
        public IEnumerable<SubViewModel> SubCategory(int mainId)
        {
            var data = _admin.AutocompleteSubCategory(mainId);
            return data;
        }

        [HttpGet("ShowProductRestaurantwise")]
        public IEnumerable<RestaurantDetailViewModal> ShowProductRestaurantwise()
        {
            var data = _admin.ShowRestaurantWiseProduct();
            return data;
        }

        [HttpGet("ShowProduct/{ResId}")]
        public IEnumerable<ProductRatingViewModel> ShowProduct(int ResId)
        {
            var data = _admin.ShowProduct(ResId);
            return data;
        }
        [HttpGet("ShowProductRestaurant/{name}")]
        public IEnumerable<RestaurantDetailViewModal> ShowProductRestaurant(string name)
        {
            var data = _admin.ShowproductRestaurant(name);
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



        [HttpGet("myU")]
        public IEnumerable<string> myU(string pre)
        {
            var data = _admin.MyUser(pre);
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
        [HttpGet("ShowUser1/{name}")]
        public async Task<IEnumerable<User_Data>> ShowUser1(string name)
        {

            var data = await _admin.ShowUser1(name);
            return data;
        }
        [HttpGet("ShowRestaurant")]
        public IEnumerable<Restaurant_Detail> ShowRestaurant()
        {

            var data =  _admin.ShowRestaurant();
            return data;
        }
        [HttpGet("ShowRestaurant1/{name}")]
        public IEnumerable<Restaurant_Detail> ShowRestaurant1(string name)
        {

            var data = _admin.ShowRestaurant1(name);
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

        [HttpPost("AddSubCategory")]
        public string AddSubCategory(SubCategoryViewModel vm)
        {
            var data = _admin.AddSubCategory(vm);
            return data;
        }

        [HttpPut("updateStatus/{Id}")]
        public string ShowRestaurant(int Id, [FromBody] bool Status)
        {

            var data = _admin.updateStatus(Id, Status);
            return data;
        }
        
    }
}
