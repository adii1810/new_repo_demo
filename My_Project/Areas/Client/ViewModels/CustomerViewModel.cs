using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Project.Areas.Client.ViewModels
{
    public class CustomerViewModel
    {
        public int User_Id { get; set; }
        public string User_FirstName { get; set; }
        public string User_LastName { get; set; }
        public string User_UserName { get; set; }
        public string User_Password { get; set; }
        public string User_Address { get; set; }
        public string User_PhoneNo { get; set; }
        public string User_Email { get; set; }
        public string User_City { get; set; }
        public string User_State { get; set; }
        public int User_ZipCode { get; set; }
    }
}
