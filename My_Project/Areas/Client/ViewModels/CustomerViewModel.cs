using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Client.ViewModels
{
    public class CustomerViewModel
    {
        public int User_Id { get; set; }
        [Required]
        public string User_FirstName { get; set; }
        [Required]
        public string User_LastName { get; set; }
        [Required]
        public string User_UserName { get; set; }
        [Required]
        public string User_Password { get; set; }
        [Required]
        public string User_Address { get; set; }
        [Required]
        public string User_PhoneNo { get; set; }
        [Required]
        public string User_Email { get; set; }
        [Required]
        public string User_City { get; set; }
        [Required]
        public string User_State { get; set; }
        [Required]
        public int User_ZipCode { get; set; }
    }
}
