using DataAccessLayer;
using Food_Delivery_Api.ViewModel;
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
    }
}
