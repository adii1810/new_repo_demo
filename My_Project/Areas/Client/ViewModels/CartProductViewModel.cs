using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Client.ViewModels
{
    public class CartProductViewModel
    {
        public DateTime Order_Date { get; set; }
        public int User_DataId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string ImgLink { get; set; }
    }
}
