using DataAccessLayer;
using Food_Delivery_Api.Data;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public class AdminMethod : IAdminInterface
    {
        private readonly ApplicationDbContext _context;
        public AdminMethod(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AdminLogin(string user, string pass)
        {
            var Data =  _context.User_Data.Where(x => x.User_UserName == user && x.User_Password == pass).Count();
            return Data;
        }

        public IList<SelectListItem> AutocompleteMainCategory()
        {
            var data = Enum.GetValues(typeof(Main)).Cast<Main>().Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = ((int)x).ToString()
            }).ToList();
           
            return data;
        }

        public IEnumerable<SubViewModel> AutocompleteSubCategory(int mainId)
        {
            var data = _context.Sub_Categorie.Where(x => (int)x.Main_Category_Id == mainId).Select(x=> new { 
            x.Sub_Category_Id,
            x.Sub_Category_Name
            }).ToList();
            List<SubViewModel> l = new List<SubViewModel>();
            foreach (var item in data)
            {
                SubViewModel vm = new SubViewModel();
                vm.sub_Category_Id = item.Sub_Category_Id;
                vm.Sub_Category_Name = item.Sub_Category_Name;

                l.Add(vm);
            }
            return l;
        }

        public IEnumerable<string> MyRestaurant(string pre)
        {
           
            var data = _context.Restaurant_Detail.Where(x => x.Restaurant_Detail_Name.StartsWith(pre)).Select(x => x.Restaurant_Detail_Name).ToList();
            return data;
        }

        public IEnumerable<string> MyUser(string pre)
        {

            var data = _context.User_Data.Where(x => x.User_FirstName.StartsWith(pre)).Select(x => x.User_FirstName).ToList();
            return data;
        }

        public async Task<IEnumerable<OrderDetailViewModel>> OrderDetailsPerUser(int OrderId)
        {
            List<OrderDetailViewModel> ol = new List<OrderDetailViewModel>();
            var data = await _context.Order_Detail.Where(x => x.OrderId == OrderId).ToListAsync();
            foreach (var item in data)
            {
                OrderDetailViewModel vm = new OrderDetailViewModel();
                vm.Order_Detail_Id = item.Order_Detail_Id;
                vm.Quantity = item.Quantity;
                var data1 = _context.Product.Where(x => x.Product_Id == item.ProductId).FirstOrDefault();
                vm.Product_name = data1.Product_Name;
                vm.Price = data1.Product_Price * item.Quantity ;

                ol.Add(vm);
            }
            return ol;
        }

        public async Task<IEnumerable<OrderViewModel>> OrderPerUser(int UserId)
        {
            List<OrderViewModel> ol = new List<OrderViewModel>();
            var data = await _context.Order.Where(x => x.User_DataId == UserId).OrderByDescending(x=>x.Order_Id).ToListAsync();

            foreach (var item in data)
            {
                OrderViewModel vm = new OrderViewModel();
                vm.Order_Id = item.Order_Id;
                vm.Order_Date = item.Order_Date.ToString("d");
                vm.Valet_id = item.ValetId;
                var data2 = _context.Order_Detail.Where(x => x.OrderId == item.Order_Id).ToList();
                int sum = 0;
                foreach (var item2 in data2)
                {
                    int price = _context.Product.Where(x => x.Product_Id == item2.ProductId).Select(x => x.Product_Price).FirstOrDefault();
                    sum += price * item2.Quantity;
                }
                vm.Total = sum;
                ol.Add(vm);
                sum = 0;
            }
            return ol;
        }

        public IEnumerable<ProductRatingViewModel> ShowProduct()
        { 
            var data = _context.Product.ToList();
            
            List<ProductRatingViewModel> l = new List<ProductRatingViewModel>();

            foreach (var item in data)
            {
                double rate = 5;
                int user = 0;
                if ((user = _context.User_Rating.Where(x => x.ProductId == item.Product_Id).Count()) > 0)
                {
                    rate = _context.User_Rating.Where(x => x.ProductId == item.Product_Id).Average(x => x.User_Rating_Star);
                }
                ProductRatingViewModel p = new ProductRatingViewModel();
                p.Product_Id = item.Product_Id;
                p.Product_Name = item.Product_Name;
                p.Product_Price = item.Product_Price;
                p.Product_Status = item.Product_Status;
                p.rate = rate;
                p.user = user;
                l.Add(p);
            }
            return l;
        }
        public IEnumerable<ProductRatingViewModel> ShowProduct(int mainId, string name)
        {
            List<Product> data ;            
            if (mainId >= 0 && name.Equals("null"))
            {
                data = _context.Product.Include("Sub_Category").Where(x => (int)x.Sub_Category.Main_Category_Id == mainId).ToList();
            }
            else if (mainId < 0 && name != "null")
            {
                data = _context.Product.Include("Restaurant_Detail").Where(x => x.Restaurant_Detail.Restaurant_Detail_Name == name).ToList();
            }
            else if(mainId >= 0 && name != "null")
            {
                data = _context.Product.Include("Restaurant_Detail").Include("Sub_Category").Where(x => x.Restaurant_Detail.Restaurant_Detail_Name == name && (int)x.Sub_Category.Main_Category_Id == mainId).ToList();
            }
            else
            {
                data = _context.Product.ToList(); 
            }

            
            List<ProductRatingViewModel> l = new List<ProductRatingViewModel>();
            foreach (var item in data)
            {
                double rate = 5;
                int user = 0;
                if ( (user = _context.User_Rating.Where(x => x.ProductId == item.Product_Id).Count()) > 0)
                {
                    rate = _context.User_Rating.Where(x => x.ProductId == item.Product_Id).Average(x => x.User_Rating_Star);
                }
                ProductRatingViewModel p = new ProductRatingViewModel();
                p.Product_Id = item.Product_Id;
                p.Product_Name = item.Product_Name;
                p.Product_Price = item.Product_Price;
                p.Product_Status = item.Product_Status;
                p.rate = rate;
                p.user = user;
                l.Add(p);
            }
            return l;
        }

        public async Task<IEnumerable<User_Data>> ShowUser()
        {
            var data = await _context.User_Data.OrderByDescending(x => x.User_Id).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<User_Data>> ShowUser1(string name)
        {
            var data = await _context.User_Data.Where(x=>x.User_FirstName == name).OrderByDescending(x => x.User_Id).ToListAsync();
            return data;
        }

        public IEnumerable<Restaurant_Detail> ShowRestaurant()
        {
            var data = _context.Restaurant_Detail.ToList();
            return data;
        }
        public string updateStatus(int Id, bool Status)
        {
            if ((_context.Restaurant_Detail.Where(x => x.Restaurant_Detail_Id == Id).Count()) > 0)
            {
                var data = _context.Restaurant_Detail.Where(x => x.Restaurant_Detail_Id == Id).FirstOrDefault();
                data.status_by_Admin = Status;
                _context.SaveChanges();
                return "true";
            }
            return "false";
        }
    }
}
