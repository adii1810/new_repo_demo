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

        public int RestaurantLogin(string uname, string pass)
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
            var data = _context.Sub_Categorie.Select(x => new
            {
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



        public async Task<int> StoringImages(ProductImageViewModel pmvm)
        {
            ProductImages pm = new ProductImages();
            pm.imgName = pmvm.imgName;
            pm.ProductId = pmvm.ProductId;
            pm.Restaurant_DetailId = pmvm.Restaurant_DetailId;
            pm.ImgLink = null;

            _ = await _context.ProductImages.AddAsync(pm);
            _context.SaveChanges();
            return 1;
        }
        public async Task<int> GetCurrentRecordId()
        {
            var data = await _context.Product.OrderByDescending(x => x.Product_Id).Take(1).Select(x => x.Product_Id).FirstOrDefaultAsync();
            return data;
        }

        public IEnumerable<ProductRatingViewModel> ShowProduct(int id)
        {
            var data = _context.Product.Where(x => x.Restaurant_DetailId == id).OrderByDescending(x => x.Product_Id).ToList();

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
        public string updateStatus(int ProdId, bool Status)
        {
            var data = _context.Product.Where(x => x.Product_Id == ProdId).FirstOrDefault();
            data.Product_Status = Status;
            _context.SaveChanges();
            return "true";
        }
        public async Task<ProductViewModel> GetProductDetail(int ProdId)
        {
            var data = await _context.Product.Where(x => x.Product_Id == ProdId).FirstOrDefaultAsync();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product_Id = ProdId;
            pvm.Product_Name = data.Product_Name;
            pvm.Product_Price = data.Product_Price;
            pvm.Product_Status = data.Product_Status;
            pvm.Description = data.Description;
            pvm.FoodType = (int)data.FoodType;
            pvm.Restaurant_Detail = data.Restaurant_DetailId;
            pvm.Sub_Category = data.Sub_CategoryId;
            return pvm;
        }

        //Get images list Product wise

        public async Task<IEnumerable<ImageViewModel>> UpdateImage(int Prodid)
        {
            List<ImageViewModel> l = new List<ImageViewModel>();
            var data = await _context.ProductImages.Where(x => x.ProductId == Prodid).ToListAsync();

            foreach (var item in data)
            {
                ImageViewModel ivm = new ImageViewModel();
                ivm.ImageName = item.imgName;
                ivm.ImgId = item.Id;
                ivm.ProdId = item.ProductId;
                ivm.ResId = item.Restaurant_DetailId;
                ivm.ImgLink = item.ImgLink;

                l.Add(ivm);
            }
            return l;
        }

        public string AddImgLink(string imgName,ProductImageViewModel pvm)
        {
            var data = _context.ProductImages.Where(x => x.imgName == imgName).FirstOrDefault();
            data.ImgLink = pvm.Link;
            _context.SaveChanges();
            return "true";
        }
    }
}