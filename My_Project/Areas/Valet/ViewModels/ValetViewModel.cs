using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Valet.ViewModels
{
    public class ValetViewModel
    {
        public int Valet_Id { get; set; }
        [Required]
        public string Valet_Name { get; set; }
        [Required]
        public string Valet_Address { get; set; }
        [Required]
        public string Valet_UserName { get; set; }
        [Required]
        public string Valet_Password { get; set; }
        [Required]
        public string Valet_Email { get; set; }
        [Required]
        public string Valet_PhoneNo { get; set; }
        [Required]
        public string Valet_City { get; set; }
        [Required]
        public string Valet_State { get; set; }
        [Required]
        public string Valet_Zipcode { get; set; }
    }
}
