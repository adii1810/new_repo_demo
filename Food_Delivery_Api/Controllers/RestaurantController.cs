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
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantInterface _restaurant;

        public RestaurantController(IRestaurantInterface restaurant)
        {
            _restaurant = restaurant;
        }

        public string Get()
        {
            return "abc";
        }

        [HttpGet("RestaurantLogin/{uname?}/{pass?}")]
        public int RestaurantLogin(string uname, string pass)
        {
            var data = _restaurant.RestaurantLogin(uname, pass);
            return data;
        }


        [HttpPost("AddRestaurant")]
        public string AddRestaurant(RestaurantDetails vm)
        {
            _restaurant.AddRestaurant(vm);
            return "true";
        }
    }    
}
