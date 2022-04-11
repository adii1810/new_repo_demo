using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Restaurant.ViewModels
{
    public class ProductImageViewModel
    {
        public int Restaurant_DetailId { get; set; }
        public int ProductId { get; set; }
        public string imgName { get; set; }
        public string link { get; set; }
        public IList<IFormFile> images { get; set; }
    }
}
