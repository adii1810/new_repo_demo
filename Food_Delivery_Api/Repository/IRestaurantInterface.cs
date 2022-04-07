using DataAccessLayer;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public interface IRestaurantInterface
    {
        public string AddRestaurant(RestaurantDetails vm);
        public int RestaurantLogin(string uname, string pass);
        public IList<SelectListItem> AutocompleteFoodType();
        public IList<SubViewModel> AutocompleteSubCategory();
        public string AddProduct(ProductViewModel vm);
        public Task<int> StoringImages(ProductImageViewModel pm);
        public Task<int> GetCurrentRecordId();
    }
}
