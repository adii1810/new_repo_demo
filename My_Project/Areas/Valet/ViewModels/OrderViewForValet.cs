using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Valet.ViewModels
{
    public class OrderViewForValet
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public string RestaurantAddress { get; set; }
        public string UserAddress { get; set; }
        public int OrderStatus { get; set; }
    }
}
