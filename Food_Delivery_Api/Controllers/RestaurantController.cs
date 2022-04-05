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
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantInterface _restaurant;

        public RestaurantController(IRestaurantInterface restaurant)
        {
            _restaurant = restaurant;
        }

        [HttpPost]
        public string AddRestaurant(Restaurant_Detail vm)
        {

            return "true";
        }
    }
}
