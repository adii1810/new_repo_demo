using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Restaurant.ViewModels
{
    public class ShowOrderViewModel
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public int OrderStatus { get; set; }
        public int TotalPrice { get; set; }
    }
}
