using DataAccessLayer;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
   public interface IAdminInterface
    {
        public int AdminLogin(string user, string pass);
        public Task<IEnumerable<User_Data>> ShowUser();
        public Task<IEnumerable<User_Data>> ShowUser1(string name);
        public Task<IEnumerable<OrderViewModel>> OrderPerUser(int UserId);
        public Task<IEnumerable<OrderDetailViewModel>> OrderDetailsPerUser(int OrderId);
        public IList<SelectListItem> AutocompleteMainCategory();
        public IEnumerable<SubViewModel> AutocompleteSubCategory(int mainId);
        public IEnumerable< string> MyRestaurant(string pre);
        public IEnumerable< string> MyUser(string pre);
        public IEnumerable<ProductRatingViewModel> ShowProduct();
        public IEnumerable<ProductRatingViewModel> ShowProduct(int id,string name);
        public IEnumerable<Restaurant_Detail> ShowRestaurant();
        public IEnumerable<Restaurant_Detail> ShowRestaurant1(string name);
        public string updateStatus(int Id,bool Status);

    }
}
