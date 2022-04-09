using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
   public class ProductImages
    {
        public int Id { get; set; }
        public int Restaurant_DetailId { get; set; }
        public int ProductId { get; set; }
        public string imgName { get; set; }
        public string ImgLink { get; set; }

    }
}
