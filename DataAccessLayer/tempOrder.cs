using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer
{
    public class tempOrder
    {
        [Key]
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int User_DataId { get; set; }
        
        public int? ValetId { get; set; }
        public User_Data User_Data { get; set; }
        public Valet Valet { get; set; }
        public ICollection<tempOrderDetails> tempOrder_Details { get; set; } = new HashSet<tempOrderDetails>();
    }
}
