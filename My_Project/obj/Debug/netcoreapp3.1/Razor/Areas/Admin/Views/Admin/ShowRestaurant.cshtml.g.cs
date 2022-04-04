#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowRestaurant.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cdb7f7075d5703f1beb422428188c1e905b53ec8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admin_ShowRestaurant), @"mvc.1.0.view", @"/Areas/Admin/Views/Admin/ShowRestaurant.cshtml")]
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
#line 1 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Admin\Views\_ViewImports.cshtml"
using My_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Admin\Views\_ViewImports.cshtml"
using My_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cdb7f7075d5703f1beb422428188c1e905b53ec8", @"/Areas/Admin/Views/Admin/ShowRestaurant.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Admin_ShowRestaurant : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Admin.ViewModels.RestaurantViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Admin\Views\Admin\ShowRestaurant.cshtml"
  
    ViewData["Title"] = "ShowRestaurant";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

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
                    content: attr(aria-label);
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

    /*CheckBox css toggle*/





    /* Switch 1 Specific Styles Start */

    .box_1 {
        background: #eee;
    }

    input[type=""checkbox""].switch_1 {
        font-size: 20px;
        -webkit-appearance: none;
        -moz-appearance: none;
        appearance: none;
        width: 1em;
        height: 1em;
        background: #ff0000;
        border-radius: 2em;
        position: relative;
        cursor: pointer;
        outline: none;
        -webkit-transition: all .2s ease-in-out;
        transition: all .2s ease-in-out;
    }

       ");
            WriteLiteral(@" input[type=""checkbox""].switch_1:checked {
            background: #0ebeff;
        }

        input[type=""checkbox""].switch_1:after {
            position: absolute;
            content: """";
            width: 1em;
            height: 1em;
            border-radius: 50%;
            background: #fff;
            -webkit-box-shadow: 0 0 .25em rgba(0,0,0,.3);
            box-shadow: 0 0 .25em rgba(0,0,0,.3);
            -webkit-transform: scale(.7);
            transform: scale(.7);
            left: 0;
            -webkit-transition: all .2s ease-in-out;
            transition: all .2s ease-in-out;
        }

        input[type=""checkbox""].switch_1:checked:after {
            left: calc(100% - 1.5em);
        }

    /* Switch 1 Specific Style End */
    /*================Spinner====================*/

    .lds-dual-ring {
        display: inline-block;
        width: 30px;
        height: 30px;
    }

        .lds-dual-ring:after {
            content: """";
            displa");
            WriteLiteral(@"y: block;
            width: 30px;
            height: 30px;
            margin: 1px;
            border-radius: 50%;
            border: 2px solid #fff;
            border-color: green transparent deepskyblue transparent;
            animation: lds-dual-ring 1.2s linear infinite;
        }

    ");
            WriteLiteral(@"@keyframes lds-dual-ring {
        0% {
            transform: rotate(0deg);
        }

        100% {
            transform: rotate(360deg);
        }
    }
</style>

<div class=""py-4"">
    <label class=""text-blue""><i class=""fa-solid fa-fork-knife""> Restaurant</i></label>
</div>

");
            WriteLiteral("<table class=\"table\">\r\n    <tr class=\"row border-0\">\r\n\r\n        <td class=\"col-10 border-0\">\r\n            <input type=\"text\"");
            BeginWriteAttribute("value", " value=\"", 4706, "\"", 4714, 0);
            EndWriteAttribute();
            WriteLiteral(@" name=""restaurant_Name"" class=""form-control"" id=""Name"" placeholder=""Restaurant"" />
        </td>
        <td class=""col-2 border-0"" "">

            <input type=""button"" class=""btn btn-warning text-dark form-control"" id=""btnSearchRestaurant"" value=""Search"" />
        </td>
    </tr>
</table>

<div class=""customtbl"">
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    Restaurant Id
                </th>
                <th>
                    Reastaurant Name
                </th>
                <th>
                    Restaurant Email
                </th>
                <th>
                    Restaurant Status
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
        </tbody>
    </table>

</div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<My_Project.Areas.Admin.ViewModels.RestaurantViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591