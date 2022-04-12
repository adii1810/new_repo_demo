﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Restaurant.ViewModels
{
    public class RestaurantDetailViewModel
    {
        public int Restaurant_Detail_Id { get; set; }
        public string Restaurant_Detail_Name { get; set; }
        public string Restaurant_Detail_User_Name { get; set; }
        public string Restaurant_Detail_Password { get; set; }
        public string Restaurant_Detail_Address { get; set; }
        public string Restaurant_Detail_PhoneNo { get; set; }
        public string Restaurant_Detail_Email { get; set; }
        public string Restaurant_Detail_City { get; set; }
        public string Restaurant_Detail_State { get; set; }
        public string Restaurant_Detail_Zipcode { get; set; }
        public bool status_by_Admin { get; set; }
        public string profileImage { get; set; }
        public IFormFile img { get; set; }

    }
}
