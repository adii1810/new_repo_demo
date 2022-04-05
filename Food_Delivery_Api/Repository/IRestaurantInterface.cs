using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public interface IRestaurantInterface
    {
        public string AddRestaurant(Restaurant_Detail vm);
    }
}
