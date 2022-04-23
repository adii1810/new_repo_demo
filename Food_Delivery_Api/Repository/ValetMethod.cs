using DataAccessLayer;
using Food_Delivery_Api.Data;
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
                _context.Valet.Add(val);
                _context.SaveChanges();
                return "true";
            }
            return "false";            
        }
        //public IEnumerable<OrderViewForValet> ShowOrder()
        //{
        //    var data = _context.Order.Where(x => x.Order_Status_Id == (OrderStatus)1).ToList();
        //    List<OrderViewForValet> lvm = new List<OrderViewForValet>();
        //    foreach (var item in data)
        //    {
        //        OrderViewForValet od = new OrderViewForValet();
        //        od.OrderId = item.Order_Id;
        //        od.OrderDate = item.Order_Date.ToString("D");
        //        od.UserAddress = _context.Order_Detail.
        //    }
        //    return lvm;
        //}
    }
}
