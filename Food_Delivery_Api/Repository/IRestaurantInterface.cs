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
        public Restaurant_Detail RestaurantLogin(string uname, string pass);
        public IList<SelectListItem> AutocompleteFoodType();
        public IList<SubViewModel> AutocompleteSubCategory();
        public string AddProduct(ProductViewModel vm);
        public Task<int> StoringImages(ProductImageViewModel pm);
        public Task<int> GetCurrentRecordId();
        public IEnumerable<ProductRatingViewModel> ShowProduct(int id);
        public string updateStatus(int ProdId, bool Status);
        public Task<ProductViewModel> GetProductDetail(int ProdId);
        public Task<IEnumerable<ImageViewModel>> UpdateImage(int Prodid);
        public string AddImgLink(string imgName,ProductImageViewModel pvm);
        public string DeleteImage(string id);
        public IEnumerable<string> MyProduct(string pre);
        public IEnumerable<ProductRatingViewModel> ShowProduct(int mainId, string name,int resId);

        public string EditProduct(int id, ProductViewModel pvm);
        public Restaurant_Detail GetRestaurantDetail(int id);
        public string EditRestaurant(Restaurant_Detail rd);
        public int RestaurantConfirmPassword(string username, string password);
        public string ChangePassword(string username, string password);
        public IEnumerable<ShowOrderViewModel> GetUnApprovedOrders(int ResId);
        public string UpdateOrderStatus(int OrdId);
        public Task<IEnumerable<OrderDetailViewModel>> ShowOrderDetail(int OrderId);
        public int verifyAccount(string Username, string Email);
        public IEnumerable<ShowOrderViewModel> GetApprovedOrders(int ResId);
    }
}
