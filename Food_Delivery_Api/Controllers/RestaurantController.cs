using DataAccessLayer;
using Food_Delivery_Api.Repository;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public Restaurant_Detail RestaurantLogin(string uname, string pass)
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
        [HttpGet("GetRestaurantDetails/{id}")]
        public Restaurant_Detail GetRestaurantDetails(int id)
        {
            var data = _restaurant.GetRestaurantDetail(id);
            return data;
        }
        [HttpPost("AddProduct")]
        public string AddProduct(ProductViewModel vm)
        {
            _restaurant.AddProduct(vm);
            return "true";
        }

        [HttpPost("StoringImage")]
        public async Task<int> StoringImage(ProductImageViewModel vm)
        {
            var data = await _restaurant.StoringImages(vm);
            return data;
        }
        [HttpGet("FoodType")]
        public IList<SelectListItem> FoodType()
        {
            var data = _restaurant.AutocompleteFoodType();
            return data;
        }
        [HttpGet("SubCategory")]
        public IList<SubViewModel> SubCategory()
        {
            var data = _restaurant.AutocompleteSubCategory();
            return data;
        }
        [HttpGet("GetCurrentRecordId")]
        public async Task<int> GetCurrentRecordId()
        {
            var data = await _restaurant.GetCurrentRecordId();
            return data;
        }

        [HttpGet("ShowProduct/{id}")]
        public IEnumerable<ProductRatingViewModel> ShowProduct(int id)
        {
            var data = _restaurant.ShowProduct(id);
            return data;
        }

        [HttpGet("DeleteImage/{id}")]
        public void DeleteImage(string id)
        {
            _restaurant.DeleteImage(id);

        }
        [HttpGet("ChangeStatus/{id}/{status}")]
        public string ChangeStatus(int id, bool status)
        {
            var data = _restaurant.updateStatus(id, status);
            return data;
        }
        [HttpGet("GetProductDetail/{id}")]
        public async Task<ProductViewModel> GetProductDetail(int id)
        {
            var data = await _restaurant.GetProductDetail(id);
            return data;
        }

        [HttpGet("UpdateImage/{id}")]
        public async Task<IEnumerable<ImageViewModel>> UpdateImage(int id)
        {
            var data = await _restaurant.UpdateImage(id);
            return data;
        }

        [HttpGet("ChangePassword/{uname}/{pass}")]
        public string ChangePassword(string uname,string pass)
        {
            var data = _restaurant.ChangePassword(uname,pass);
            return data;
        }

        [HttpGet("RestaurantConfirmPass/{username}/{password}")]
        public async Task<int> RestaurantConfirmPass(string username,string password)
        {
            var data =  _restaurant.RestaurantConfirmPassword(username, password);
            return data;
        }

        [HttpPut("imgLink/{uniqueName}")]
        public string imgLink(string uniqueName, ProductImageViewModel pvm)
        {
            var data = _restaurant.AddImgLink(uniqueName, pvm);
            return "true";
        }

        [HttpGet("myP")]
        public IEnumerable<string> myP(string pre)
        {
            var data = _restaurant.MyProduct(pre);
            return data;
        }
        [HttpGet("ShowProduct/{mainId}/{name}/{resId}")]
        public IEnumerable<ProductRatingViewModel> ShowProduct(int mainId, int resId, string name = null)
        {
            var data = _restaurant.ShowProduct(mainId, name, resId);
            return data;
        }
        [HttpPut("EditProduct/{id}")]
        public string EditProduct(int id,ProductViewModel pvm)
        {
            var result = _restaurant.EditProduct(id, pvm);
            return "true";
        }
        [HttpPost("EditRestaurantDetails")]
        public void EditRestaurantDetails(Restaurant_Detail rd)
        {
            _restaurant.EditRestaurant(rd);
        }
    }    
}
