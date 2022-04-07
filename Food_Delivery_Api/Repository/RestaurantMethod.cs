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

        public IList<SelectListItem> AutocompleteFoodType()
        {
            var data = Enum.GetValues(typeof(FoodType)).Cast<FoodType>().Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = ((int)x).ToString()
            }).ToList();

            return data;
        }

        public IList<SubViewModel> AutocompleteSubCategory()
        {
            var data = _context.Sub_Categorie.Select(x => new {
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

        public string AddProduct(ProductViewModel vm)
        {
            Product p = new Product();
            p.Product_Name = vm.Product_Name;
            p.Product_Price = vm.Product_Price;
            p.Product_Status = vm.Product_Status;
            p.Restaurant_DetailId = vm.Restaurant_Detail;
            p.Description = vm.Description;
            p.FoodType = (FoodType)vm.FoodType;
            p.Sub_CategoryId = vm.Sub_Category;
            _context.Product.Add(p);
            _context.SaveChanges();
            return "true";
        }
        


        public async Task<int> StoringImages(ProductImageViewModel pmvm) {
            ProductImages pm = new ProductImages();
            pmvm.imgName = pm.imgName;
            pmvm.ProductId = pm.ProductId;
            pmvm.Restaurant_DetailId = pm.Restaurant_DetailId;

            _ = await _context.ProductImages.AddAsync(pm);
            return 1;        
        }
        public async Task<int> GetCurrentRecordId()
        {
            var data = await _context.Product.OrderByDescending(x => x.Product_Id).Take(1).Select(x => x.Product_Id).FirstOrDefaultAsync();
            return data;
        }
    }
}
