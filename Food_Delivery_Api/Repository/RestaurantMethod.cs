using DataAccessLayer;
using Food_Delivery_Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public class RestaurantMethod : IRestaurantInterface
    {
        private readonly ApplicationDbContext _context;

        public RestaurantMethod(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AddRestaurant(Restaurant_Detail vm)
        {
            _context.Restaurant_Detail.Add(vm);
            _context.SaveChanges();
            return "true";
        }
    }
}
