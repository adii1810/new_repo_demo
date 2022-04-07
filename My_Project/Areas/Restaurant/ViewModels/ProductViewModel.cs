using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Restaurant.ViewModels
{
    public class ProductViewModel
    {
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Price { get; set; }
        public string Description { get; set; }
        public int Sub_Category { get; set; }
        public int Restaurant_Detail { get; set; }
        public int FoodType { get; set; }
        public bool Product_Status { get; set; }
        
        public IList<IFormFile> images { get; set; }
    }
}
