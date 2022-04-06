using DataAccessLayer;
using Food_Delivery_Api.Data;
using Food_Delivery_Api.ViewModel;
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

        public string AddRestaurant(RestaurantDetails vm)
        {
            Restaurant_Detail rd = new Restaurant_Detail();
            rd.Restaurant_Detail_Address = vm.Restaurant_Detail_Address;
            rd.Restaurant_Detail_City = vm.Restaurant_Detail_City;
            rd.Restaurant_Detail_Email = vm.Restaurant_Detail_Email;
            rd.Restaurant_Detail_Name = vm.Restaurant_Detail_Name;
            rd.Restaurant_Detail_Password = vm.Restaurant_Detail_Password;
            rd.Restaurant_Detail_PhoneNo = vm.Restaurant_Detail_PhoneNo;
            rd.Restaurant_Detail_State = vm.Restaurant_Detail_State;
            rd.Restaurant_Detail_User_Name = vm.Restaurant_Detail_User_Name;
            rd.Restaurant_Detail_Zipcode = vm.Restaurant_Detail_Zipcode;
            _context.Restaurant_Detail.Add(rd);
            _context.SaveChanges();
            return "true";
        }

        public int RestaurantLogin(string uname,string pass)
        {
            var data = _context.Restaurant_Detail.Where(x => x.Restaurant_Detail_User_Name == uname && x.Restaurant_Detail_Password == pass).Select(x => x.Restaurant_Detail_Id).FirstOrDefault();
            return data;
        }
    }
}
