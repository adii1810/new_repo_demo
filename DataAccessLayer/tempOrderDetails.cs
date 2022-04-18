using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class tempOrderDetails
    {
        [Key]
        public int Order_Detail_Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public tempOrder Order { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
