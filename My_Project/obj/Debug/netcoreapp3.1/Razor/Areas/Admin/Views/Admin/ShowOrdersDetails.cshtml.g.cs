#pragma checksum "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ec6eb8f3423935dce5125d9bd7934e6385b6c42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admin_ShowOrdersDetails), @"mvc.1.0.view", @"/Areas/Admin/Views/Admin/ShowOrdersDetails.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\_ViewImports.cshtml"
using My_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\_ViewImports.cshtml"
using My_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ec6eb8f3423935dce5125d9bd7934e6385b6c42", @"/Areas/Admin/Views/Admin/ShowOrdersDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8039bf55ff2b34b8f27e3e86689bf0e0814999c7", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Admin_ShowOrdersDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Admin.ViewModels.OrderDetailViewModel>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml"
  
    ViewData["Title"] = "ShowOrdersDetails";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    table {
        border: 1px solid #ccc;
        border-collapse: collapse;
        margin: 0;
        padding: 0;
        width: 100%;
        table-layout: fixed;
    }

        table caption {
            font-size: 1.5em;
            margin: .5em 0 .75em;
        }

        table tr {
            background-color: #f8f8f8;
            border: 1px solid #ddd;
            padding: .35em;
        }

        table th,
        table td {
            padding: .625em;
            text-align: center;
        }

        table th {
            font-size: .85em;
            letter-spacing: .1em;
            text-transform: uppercase;
        }

    ");
            WriteLiteral(@"@media screen and (max-width: 600px) {
        table {
            border: 0;
        }

            table caption {
                font-size: 1.3em;
            }

            table thead {
                border: none;
                clip: rect(0 0 0 0);
                height: 1px;
                margin: -1px;
                overflow: hidden;
                padding: 0;
                position: absolute;
                width: 1px;
            }

            table tr {
                border-bottom: 3px solid #ddd;
                display: block;
                margin-bottom: .625em;
            }

            table td {
                border-bottom: 1px solid #ddd;
                display: block;
                font-size: .8em;
                text-align: right;
            }

                table td::before {
                    /*
                    * aria-label has no advantage, it won't be read inside a table
                    content: attr(aria-label);");
            WriteLiteral(@"
                    */
                    content: attr(data-label);
                    float: left;
                    font-weight: bold;
                    text-transform: uppercase;
                }

                table td:last-child {
                    border-bottom: 0;
                }
    }
    /* general styling */
    body {
        font-family: ""Open Sans"", sans-serif;
        line-height: 1.25;
    }

</style>

<div class=""py-4"">
<i class=""fa-solid fa-calendar-day""> Order Details</i>
</div>

<table class=""table"">
    <thead>
        <tr>
            <th>
               Item No
            </th>
            <th>
                Product Name
            </th>
            <th>
                Quantity
            </th>
            <th>
                Total(Product Price * Quantity)
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 119 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td data-label=\"Item No\">\r\n              <b>");
#nullable restore
#line 122 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml"
            Write(Html.DisplayFor(modelItem => item.Order_Detail_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n            </td>\r\n            <td data-label=\"Product Name\">\r\n                ");
#nullable restore
#line 125 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Product_name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td data-label=\"Quantity\">\r\n                ");
#nullable restore
#line 128 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td data-label=\"Total(Product Price * Quantity)\">\r\n               <i class=\"fa-solid fa-indian-rupee-sign\"> ");
#nullable restore
#line 131 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml"
                                                    Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</i>\r\n            </td>\r\n            \r\n        </tr>\r\n");
#nullable restore
#line 135 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<hr />\r\n<div >\r\n<label class=\"d-flex justify-content-between\" ><b>Grand Total</b> <i class=\"fa-solid fa-indian-rupee-sign\"> ");
#nullable restore
#line 140 "F:\my_data\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowOrdersDetails.cshtml"
                                                                                                       Write(ViewBag.total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></label>\r\n</div>\r\n<hr />\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<My_Project.Areas.Admin.ViewModels.OrderDetailViewModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
