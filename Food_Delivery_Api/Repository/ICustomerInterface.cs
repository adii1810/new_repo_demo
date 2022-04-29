using DataAccessLayer;
using Food_Delivery_Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
   public interface ICustomerInterface
    {
        public string AddCustomer(User_Data ud);
        public Task<User_Data> LoginCustomer(string uname, string pass);
        public Task<IEnumerable<ProductforCustomerViewModel>> ShowProduct(string tab);
        public string AddProductCart(CartProductViewModel vm);
        public IEnumerable<CartProductViewModel> ViewProductCart(int userId);
        public string deleteProduct(int ProdId, int userId);
        public string IncrementDecrement(string status, int prodId, int userId);
        public string CheckOut(int userId);
        public IEnumerable<ShowOrderViewModel> ShowOrder(int userId);
        public IEnumerable<CartProductViewModel> ShowOrderDetail(int userId, int ordId);
        public IEnumerable<Restaurant_Detail> ShowRestaurant();
        public IEnumerable<string> MyRestaurant(string pre);
        public IEnumerable<ProductforCustomerViewModel> ShowRestaurantProduct(string resName);
        public int ViewRating(int userId, int ProdId);
        public string AddRating(int userId, int ProdId,int rate);
        public User_Data GetUser(int userId);
        public string UpdateUser(User_Data vm);
        public int UserConfirmPassword(string username, string password);
        public string ChangePassword(string username, string password);

    }
}
