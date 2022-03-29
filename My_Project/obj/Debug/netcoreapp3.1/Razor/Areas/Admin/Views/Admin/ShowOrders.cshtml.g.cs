#pragma checksum "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd8949fb3c93c1dc4470d8f1d126ee035df40066"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Admin_ShowOrders), @"mvc.1.0.view", @"/Areas/Admin/Views/Admin/ShowOrders.cshtml")]
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
#line 1 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\_ViewImports.cshtml"
using My_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\_ViewImports.cshtml"
using My_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd8949fb3c93c1dc4470d8f1d126ee035df40066", @"/Areas/Admin/Views/Admin/ShowOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Admin_ShowOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Admin.ViewModels.OrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-blue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ShowOrdersDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
  
    ViewData["Title"] = "ShowOrders";
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
                    */
             ");
            WriteLiteral(@"       content: attr(data-label);
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
    <label class=""text-blue""><i class=""fa-brands fa-opencart""> User Details</i></label>
</div>

<table class=""table"">
    <tr>
        <td>
            <input  />
        </td>
    </tr>
</table>

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
                Valet Id
            </th>
            <th>
                Total
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 128 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td data-label=\"Order Id\">\n                    ");
#nullable restore
#line 132 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Order_Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td data-label=\"Order Date\">\n                    ");
#nullable restore
#line 135 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Order_Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td data-label=\"Valet Id\">\n                    ");
#nullable restore
#line 138 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Valet_id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td data-label=\"Total\">\n                    ");
#nullable restore
#line 141 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
               Write(Html.DisplayFor(modelItem => item.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </td>\n                <td>\n                  ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd8949fb3c93c1dc4470d8f1d126ee035df400669102", async() => {
                WriteLiteral("<i class=\"fa-solid fa-burger-fries\">Orders Details</i> ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-Id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 144 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
                                                                                               WriteLiteral(item.Order_Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-Id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["Id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 144 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
                                                                                                                                WriteLiteral(item.Total);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["total"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-total", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["total"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n                </td>\n            </tr>\n");
#nullable restore
#line 148 "C:\Users\Ulcom31\source\repos\AdityaMVC\Demo_Project\My_Project\Areas\Admin\Views\Admin\ShowOrders.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\n</table>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<My_Project.Areas.Admin.ViewModels.OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
