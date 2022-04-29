using DataAccessLayer;
using Food_Delivery_Api.Data;
using Food_Delivery_Api.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoreLinq;
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
            rd.profileImage = vm.profileImage;
            _context.Restaurant_Detail.Add(rd);
            _context.SaveChanges();
            return "true";
        }

        public Restaurant_Detail RestaurantLogin(string uname, string pass)
        {
            var data = _context.Restaurant_Detail.Where(x => x.Restaurant_Detail_User_Name == uname && x.Restaurant_Detail_Password == pass && x.status_by_Admin == true).FirstOrDefault();
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

        public void DeleteImage(string id)
        {
            var Id = Convert.ToInt32(id);
            var data = _context.ProductImages.Where(x => x.Id == Id).FirstOrDefault();
            _context.ProductImages.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<string> MyProduct(string pre)
        {

            var data = _context.Product.Where(x => x.Product_Name.StartsWith(pre)).Select(x => x.Product_Name).ToList();
            return data;
        }
        public IEnumerable<ProductRatingViewModel> ShowProduct(int mainId, string name,int resId)
        {
            List<Product> data;
            if (mainId >= 0 && name.Equals("null"))
            {
                data = _context.Product.Include("Sub_Category").Where(x => (int)x.Sub_Category.Main_Category_Id == mainId && x.Restaurant_DetailId == resId).ToList();
            }
            else if (mainId < 0 && name != "null")
            {
                data = _context.Product.Where(x => x.Product_Name == name && x.Restaurant_DetailId == resId).ToList();
            }
            else if (mainId >= 0 && name != "null")
            {
                data = _context.Product.Include("Sub_Category").Where(x => x.Product_Name == name && (int)x.Sub_Category.Main_Category_Id == mainId && x.Restaurant_DetailId == resId).ToList();
            }
            else
            {
                data = _context.Product.Where(x=>x.Restaurant_DetailId == resId).ToList();
            }


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
        public string EditProduct(int id,ProductViewModel p)
        {
            var data = _context.Product.Where(x => x.Product_Id == id).FirstOrDefault();
            data.Description = p.Description;
            data.Product_Name = p.Product_Name;
            data.Product_Price = p.Product_Price;
            _context.Product.Update(data);
            _context.SaveChanges();
            return "true";
        }

        public Restaurant_Detail GetRestaurantDetail(int id)
        {
            var data = _context.Restaurant_Detail.Where(x => x.Restaurant_Detail_Id == id).FirstOrDefault();
            return data;
        }
        public void EditRestaurant(Restaurant_Detail rd)
        {
            var data = _context.Restaurant_Detail.Where(x => x.Restaurant_Detail_Id == rd.Restaurant_Detail_Id).FirstOrDefault();
            data.profileImage = rd.profileImage;
            data.Restaurant_Detail_Address = rd.Restaurant_Detail_Address;
            data.Restaurant_Detail_City = rd.Restaurant_Detail_City;
            data.Restaurant_Detail_Email = rd.Restaurant_Detail_Email;
            data.Restaurant_Detail_Name = rd.Restaurant_Detail_Name;
            data.Restaurant_Detail_PhoneNo = rd.Restaurant_Detail_PhoneNo;
            data.Restaurant_Detail_State = rd.Restaurant_Detail_State;
            data.Restaurant_Detail_Zipcode = rd.Restaurant_Detail_Zipcode;
            _context.Restaurant_Detail.Update(data);
            _context.SaveChanges();
        }
        public int RestaurantConfirmPassword(string username,string password)
        {
            var data = _context.Restaurant_Detail.Where(x => x.Restaurant_Detail_User_Name == username && x.Restaurant_Detail_Password == password).Count();
            return data;
        }
        public string ChangePassword(string username, string password)
        {
            var data = _context.Restaurant_Detail.Where(x => x.Restaurant_Detail_User_Name == username).FirstOrDefault();
            data.Restaurant_Detail_Password = password;
            _context.Restaurant_Detail.Update(data);
            _context.SaveChanges();
            return "true";
        }

        public IEnumerable<ShowOrderViewModel> GetUnApprovedOrders(int ResId)
        {
            List<ShowOrderViewModel> lvm = new List<ShowOrderViewModel>();

            var data = _context.Order_Detail.Include("Order").Where(x => x.OrderId == x.Order.Order_Id && x.ProductId == x.Product.Product_Id && x.Product.Restaurant_DetailId == ResId && x.Order.Order_Status_Id == 0).DistinctBy(x=>x.OrderId).ToList();
            foreach (var item in data)
            {
                ShowOrderViewModel vm = new ShowOrderViewModel();
                vm.OrderDate = item.Order.Order_Date.ToString("D");
                vm.OrderId = item.Order.Order_Id;
                vm.OrderStatus = (int)item.Order.Order_Status_Id;
                var amt = _context.Order_Detail.Where(x => x.OrderId == item.Order.Order_Id).Sum(x => x.Product.Product_Price * x.Quantity);
                vm.TotalPrice = amt;
                lvm.Add(vm);
            }
            return lvm;
        }
        public string UpdateOrderStatus(int OrdId)
        {
            var data = _context.Order.Where(x => x.Order_Id == OrdId).FirstOrDefault();
            data.Order_Status_Id = (OrderStatus)1;
            _context.Order.Update(data);
            _context.SaveChanges();
            return "true";        
        }
        public async Task<IEnumerable<OrderDetailViewModel>> ShowOrderDetail(int OrderId)
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
                vm.Price = data1.Product_Price * item.Quantity;

                ol.Add(vm);
            }
            return ol;
        }
    }
    
}