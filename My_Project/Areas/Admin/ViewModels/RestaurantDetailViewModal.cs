using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Admin.ViewModels
{
    public class RestaurantDetailViewModal
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public int ActiveProducts { get; set; }
        public int InActiveProducts { get; set; }
    }
}
