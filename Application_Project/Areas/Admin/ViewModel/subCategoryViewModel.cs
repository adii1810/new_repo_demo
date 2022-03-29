using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application_Project.Areas.Admin.ViewModel
{
    public class subCategoryViewModel
    {
        public int sub_Category_Id { get; set; }
        public string sub_Category_Name { get; set; }

        public List<SelectListItem> subCate { get; set; }
    }
}
