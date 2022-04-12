using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Client.ViewModels
{
    public class RestaurantDetailViewModel
    {
        [Required]
        public string Restaurant_Detail_Name { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "Name length can't be more than 8.")]
        public string Restaurant_Detail_User_Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Restaurant_Detail_Password { get; set; }
        [Required]
        public string Restaurant_Detail_Address { get; set; }
        [Required]
        [Phone]
        public string Restaurant_Detail_PhoneNo { get; set; }
        [Required]
        [EmailAddress]
        public string Restaurant_Detail_Email { get; set; }
        [Required]
        public string Restaurant_Detail_City { get; set; }
        [Required]
        public string Restaurant_Detail_State { get; set; }
        [Required]
        public string Restaurant_Detail_Zipcode { get; set; }
        public string profileImage { get; set; }
        public IFormFile img { get; set; }

    }
}
