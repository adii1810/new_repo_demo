using DataAccessLayer;
using Food_Delivery_Api.Data;
using Food_Delivery_Api.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public class CustomerMethod : ICustomerInterface
    {
        private readonly ApplicationDbContext _context;

        public CustomerMethod(ApplicationDbContext context)
        {
            _context = context;
        }

        public string AddCustomer(User_Data ud)
        {
            _context.User_Data.Add(ud);
            _context.SaveChanges();
            return "true";
        }
        public async Task<User_Data> LoginCustomer(string uname,string pass)
        {
            var data = await _context.User_Data.Where(x => x.User_UserName == uname && x.User_Password == pass).FirstOrDefaultAsync();
            return data;
        }
        public async Task<IEnumerable<ProductforCustomerViewModel>> ShowProduct(string tab)
        {
            List<Product> data=null;
            List<ProductforCustomerViewModel> lvm = new List<ProductforCustomerViewModel>();
            if (tab == "tab1")
            {
                  data = _context.Product.Include("Sub_Category").Where(x => (int)x.Sub_Category.Main_Category_Id == 1).ToList();
            }
            else if (tab == "tab2")
            {
                 data = _context.Product.Include("Sub_Category").Where(x => (int)x.Sub_Category.Main_Category_Id == 0).ToList();
            }
            else if (tab == "tab3")
            {
                 data = _context.Product.Include("Sub_Category").Where(x => (int)x.Sub_Category.Main_Category_Id == 2).ToList();
            }
            else
            {
                data = _context.Product.Include("Sub_Category").ToList();
            }
            foreach (var item in data)
                {
                    ProductforCustomerViewModel p = new ProductforCustomerViewModel();
                    p.Description = item.Description;
                    p.Product_Id = item.Product_Id;
                    p.Product_Name = item.Product_Name;
                    p.Product_Price = item.Product_Price;
                    p.Product_Status = item.Product_Status;
                    var link = await _context.ProductImages.Where(x => x.ProductId == item.Product_Id).Take(1).Select(x => x.ImgLink).FirstOrDefaultAsync();
                    p.ImgLink = link;
                    lvm.Add(p);
                }
            return lvm;
        }
    }
}
