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
    }
}
