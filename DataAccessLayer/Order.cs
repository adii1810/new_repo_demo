using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
   public class Order
    {
        [Key]
        public int Order_Id { get; set; }
        public DateTime Order_Date { get; set; }
        public int User_DataId { get; set; }
        public int? ValetId { get; set; }
        public OrderStatus Order_Status_Id { get; set; }
        public User_Data User_Data { get; set; }
        public Valet Valet { get; set; }
        public ICollection<Order_Detail> Order_Details { get; set; } = new HashSet<Order_Detail>();
    }

    public enum OrderStatus
    {
        Order_Registered = 0,
        Order_Pending = 1,
        Order_Approved = 2,
        Order_Taken = 3,
        Order_On_the_way = 4,
        Delivered=5
    }
}