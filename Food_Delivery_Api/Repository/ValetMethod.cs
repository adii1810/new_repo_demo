using DataAccessLayer;
using Food_Delivery_Api.Data;
using Food_Delivery_Api.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.Repository
{
    public class ValetMethod:IValetInterface
    {
        private readonly ApplicationDbContext _context;
        public ValetMethod(ApplicationDbContext context)
        {
            _context = context;
        }

        public Valet ValetLogin(string user, string pass)
        {
            var Data = _context.Valet.Where(x => x.Valet_UserName == user && x.Valet_Password == pass).FirstOrDefault();
            return Data;
        }
        public string ValetReg(Valet val)
        {
            if(val != null)
            {
                var result = _context.Valet.Add(val);
                if (result.Entity != null)
                {
                    _context.SaveChanges();
                    return "true";
                }
            }
            return "false";            
        }
        public IEnumerable<OrderViewForValet> ShowOrder()
        {
            var data = _context.Order.Where(x => x.Order_Status_Id == (OrderStatus)1).OrderByDescending(x=>x.Order_Id).ToList();
            List<OrderViewForValet> lvm = new List<OrderViewForValet>();
            foreach (var item in data)
            {
                OrderViewForValet od = new OrderViewForValet();
                od.OrderId = item.Order_Id;
                od.OrderDate = item.Order_Date.ToString("D");
                od.UserAddress = _context.Order_Detail.Where(x => x.Order.Order_Id == item.Order_Id && x.Order.User_DataId == x.Order.User_Data.User_Id).Select(x => x.Order.User_Data.User_Address).FirstOrDefault();
                od.RestaurantAddress = _context.Order_Detail.Where(x => x.OrderId == item.Order_Id && x.ProductId == x.Product.Product_Id && x.Product.Restaurant_DetailId == x.Product.Restaurant_Detail.Restaurant_Detail_Id).Select(x => x.Product.Restaurant_Detail.Restaurant_Detail_Address).FirstOrDefault();
                od.OrderStatus = (int)item.Order_Status_Id;
                lvm.Add(od);
            }
            return lvm;
        }
        public string ApproveOrder(int OrdId,int valId)
        {
            var data = _context.Order.Where(x => x.Order_Id == OrdId).FirstOrDefault();
            data.Order_Status_Id = (OrderStatus)2;
            data.ValetId = valId;
           var result = _context.Order.Update(data);
            if (result.Entity != null)
            {
                _context.SaveChanges();
                return "true";
            }
            return "false";
        }
        public IEnumerable<OrderViewForValet> ApprovedOrders(int valId)
        {
            var data = _context.Order.Where(x => x.Order_Status_Id != OrderStatus.Order_Pending && x.Order_Status_Id != OrderStatus.Order_Registered && x.Order_Status_Id != OrderStatus.Delivered && x.ValetId == valId).OrderByDescending(x => x.Order_Id).ToList();
            List<OrderViewForValet> lvm = new List<OrderViewForValet>();
            foreach (var item in data)
            {
                OrderViewForValet od = new OrderViewForValet();
                od.OrderId = item.Order_Id;
                od.OrderDate = item.Order_Date.ToString("D");
                od.UserAddress = _context.Order_Detail.Where(x => x.Order.Order_Id == item.Order_Id && x.Order.User_DataId == x.Order.User_Data.User_Id).Select(x => x.Order.User_Data.User_Address).FirstOrDefault();
                od.RestaurantAddress = _context.Order_Detail.Where(x => x.OrderId == item.Order_Id && x.ProductId == x.Product.Product_Id && x.Product.Restaurant_DetailId == x.Product.Restaurant_Detail.Restaurant_Detail_Id).Select(x => x.Product.Restaurant_Detail.Restaurant_Detail_Address).FirstOrDefault();
                od.OrderStatus = (int)item.Order_Status_Id;
                lvm.Add(od);
            }
            return lvm;
        }
        public IEnumerable<OrderDetailForValet> ShowOrderDetails(int OrdId)
        {
            var data = _context.Order_Detail.Where(x=>x.OrderId == OrdId).ToList();
            List<OrderDetailForValet> lvm = new List<OrderDetailForValet>();
            foreach (var item in data)
            {
                OrderDetailForValet od = new OrderDetailForValet();
                od.Order_Detail_Id = item.Order_Detail_Id;
                od.Price = _context.Product.Where(x => x.Product_Id == item.ProductId).Select(x => x.Product_Price).FirstOrDefault();
                od.Product_name = _context.Product.Where(x => x.Product_Id == item.ProductId).Select(x => x.Product_Name).FirstOrDefault();
                od.Quantity = item.Quantity;
                lvm.Add(od);
            }
            return lvm;
        }
        public string ChangeStatus(int OrdId, int status)
        {
            var data = _context.Order.Where(x => x.Order_Id == OrdId).FirstOrDefault();
            data.Order_Status_Id = (OrderStatus)status+1;
            var result = _context.Order.Update(data);
            if (result.Entity != null)
            {
                _context.SaveChanges();
                return "true";
            }
            return "false";
        }
        public int ValetConfirmPassword(string username, string password)
        {
            var data = _context.Valet.Where(x => x.Valet_UserName == username && x.Valet_Password == password).Count();
            return data;
        }
        public string ChangePassword(string username, string password)
        {
            var data = _context.Valet.Where(x => x.Valet_UserName == username).FirstOrDefault();
            data.Valet_Password = password;
            var result = _context.Valet.Update(data);
            if (result.Entity != null)
            {
                _context.SaveChanges();
                return "true";
            }
            return "false";
        }

        public Valet GetValet(int ValId)
        {
            var data = _context.Valet.Where(x => x.Valet_Id == ValId).FirstOrDefault();
            return data;
        }
        public string UpdateValet(Valet vm)
        {
            if (vm != null)
            {
               var result = _context.Valet.Update(vm);
                {
                    _context.SaveChanges();
                    return "true";
                }
            }
            return "false";
        }
        public int verifyAccount(string Username, string Email)
        {
            var data = _context.Valet.Where(x => x.Valet_UserName == Username && x.Valet_Email == Email).Count();
            return data;
        }

    }
}
