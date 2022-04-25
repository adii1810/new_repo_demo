#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e391b0ba09b051e1cd2d5c02b6c306c0fdd386c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Valet_Views_Valet_Index), @"mvc.1.0.view", @"/Areas/Valet/Views/Valet/Index.cshtml")]
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
#line 1 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\_ViewImports.cshtml"
using My_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\_ViewImports.cshtml"
using My_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e391b0ba09b051e1cd2d5c02b6c306c0fdd386c", @"/Areas/Valet/Views/Valet/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Valet/Views/_ViewImports.cshtml")]
    public class Areas_Valet_Views_Valet_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Valet.ViewModels.OrderViewForValet>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_ValetLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
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
    <label class=""text-blue""><i class=""fa-brands fa-opencart""> Unapproved Orders</i></label>
</div>


<table class=""table"">
    <thead>
        <tr>
            <th>
               Order Id
            </th>
            <th>
                Order Date
            </th>
            <th>
               Restaurant Address
            </th>
            <th>
               User Address
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 119 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td data-label=\"Order Id\">\r\n                    ");
#nullable restore
#line 123 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml"
               Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td data-label=\"Order Date\">\r\n                    ");
#nullable restore
#line 126 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml"
               Write(item.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td data-label=\"Restaurant Address\">\r\n                    ");
#nullable restore
#line 129 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml"
               Write(item.RestaurantAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td data-label=\"User Address\">\r\n                    ");
#nullable restore
#line 132 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml"
               Write(item.UserAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <label class=\"btn btn-danger\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3424, "\"", 3456, 3);
            WriteAttributeValue("", 3434, "Approve(", 3434, 8, true);
#nullable restore
#line 135 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml"
WriteAttributeValue("", 3442, item.OrderId, 3442, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3455, ")", 3455, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Approve Order</label>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 138 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Valet\Views\Valet\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>
<script>
    const Approve = (ordid) => {
        $.ajax({
            url: location4 + ""ApproveOrders"",
            type: ""post"",
            data: { OrdId: ordid },
            success: (response) => {
                if (response == ""true"") {
                    window.location = location4 + ""ApprovedOrders"";
                }
                else {
                    alert(""Something went wrong"");
                }
            }

        })
    }
</script>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<My_Project.Areas.Valet.ViewModels.OrderViewForValet>> Html { get; private set; }
    }
}
#pragma warning restore 1591
