#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bad83221b2032c7c4131580fe82a8778132a5777"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Client_ShowOrderDetail), @"mvc.1.0.view", @"/Areas/Client/Views/Client/ShowOrderDetail.cshtml")]
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
#line 1 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\_ViewImports.cshtml"
using My_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\_ViewImports.cshtml"
using My_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bad83221b2032c7c4131580fe82a8778132a5777", @"/Areas/Client/Views/Client/ShowOrderDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_Client_ShowOrderDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Client.ViewModels.CartProductViewModel>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
  
    ViewData["Title"] = "Show Order Detail";
    int total = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bad83221b2032c7c4131580fe82a8778132a57773606", async() => {
                WriteLiteral(@"

    <style>
        .modal.fade {
            opacity: 1;
        }

        .table-image thead td,
        .table-image thead th {
            border: 0;
            color: #666;
            font-size: 0.8rem;
        }

        .table-image td,
        .table-image th {
            vertical-align: middle;
            text-align: center;
        }

            .table-image td.qty,
            .table-image th.qty {
                max-width: 2rem;
            }

        .price {
            margin-left: 1rem;
        }

        .modal-footer {
            padding-top: 0rem;
        }

        .quantity {
            display: flex;
            align-items: center;
            justify-content: center;
            padding: 0;
        }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<table class=""table table-image"">
    <thead>
        <tr>
            <th scope=""col""></th>
            <th scope=""col"">Product</th>
            <th scope=""col"">Price</th>
            <th scope=""col"">Quantity</th>
            <th scope=""col"">Total</th>
        </tr>
    </thead>

    <tbody>
");
#nullable restore
#line 62 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 1388, "\"", 1407, 1);
#nullable restore
#line 66 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
WriteAttributeValue("", 1394, item.ImgLink, 1394, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid img-thumbnail\" height=\"70\" width=\"70\" alt=\"Sheep\">\r\n                </td>\r\n                <td>");
#nullable restore
#line 68 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
               Write(item.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 69 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
               Write(item.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td class=\"qty\">\r\n                    ");
#nullable restore
#line 71 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
               Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n");
#nullable restore
#line 73 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
                  
                    var data = item.Price * item.Quantity;
                    total = total + data;
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td>\r\n                    ");
#nullable restore
#line 78 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
               Write(data);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 81 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n<div class=\"d-flex justify-content-end\">\r\n    <h5>Total: <span class=\"price text-success\">");
#nullable restore
#line 87 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrderDetail.cshtml"
                                           Write(total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></h5>\r\n</div>\r\n<script>\r\n    $(\'#form-modal\').ready(() => {\r\n        $(\'#close\').click(() => {\r\n            $(\'#form-modal\').hide();\r\n        })\r\n\r\n        $(\'#Checkout\').hide();\r\n    })\r\n</script>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<My_Project.Areas.Client.ViewModels.CartProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
