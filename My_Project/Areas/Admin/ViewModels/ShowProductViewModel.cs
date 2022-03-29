using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Admin.ViewModels
{
    public class ShowProductViewModel
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Price { get; set; }
        public string Description { get; set; }
        public bool Product_Status { get; set; }
    }
}
