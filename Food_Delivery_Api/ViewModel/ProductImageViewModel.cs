using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Delivery_Api.ViewModel
{
    public class ProductImageViewModel
    {
        public int Restaurant_DetailId { get; set; }
        public int ProductId { get; set; }
        public string imgName { get; set; }
        public string Link { get; set; }
    }
}
