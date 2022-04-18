#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e11cffe141952fb06775f39ebb8fecff06f2e9f4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Client_Cart), @"mvc.1.0.view", @"/Areas/Client/Views/Client/Cart.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e11cffe141952fb06775f39ebb8fecff06f2e9f4", @"/Areas/Client/Views/Client/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_Client_Cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Client.ViewModels.CartProductViewModel>>
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
#line 3 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\Cart.cshtml"
  
    ViewData["Title"] = "Cart";


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e11cffe141952fb06775f39ebb8fecff06f2e9f43509", async() => {
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

        .quantity__minus,
        .quantity__plus {
            display: block;
            width: 25px;
            height: 25px;
            margin: 0;
            background: #FF8C00;
            text-decoration: none;
          ");
                WriteLiteral(@"  text-align: center;
            line-height: 23px;
        }

            .quantity__minus:hover,
            .quantity__plus:hover {
                background: #575b71;
                color: #fff;
            }

        .quantity__minus {
            border-radius: 3px 0 0 3px;
        }

        .quantity__plus {
            border-radius: 0 3px 3px 0;
        }

        .quantity__input {
            width: 32px;
            height: 19px;
            margin: 0;
            padding: 0;
            text-align: center;
            border-top: 2px solid #dee0ee;
            border-bottom: 2px solid #dee0ee;
            border-left: 1px solid #dee0ee;
            border-right: 2px solid #dee0ee;
            background: #fff;
            color: #8184a1;
        }

        .quantity__minus:link,
        .quantity__plus:link {
            color: #8184a1;
        }

        .quantity__minus:visited,
        .quantity__plus:visited {
            color: #fff;
        }

 ");
                WriteLiteral("   </style>\r\n");
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
            <th scope=""col"">Actions</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td class=""w-25"">
                <img src=""https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/vans.png"" class=""img-fluid img-thumbnail"" alt=""Sheep"">
            </td>
            <td>Vans Sk8-Hi MTE Shoes</td>
            <td>89$</td>
            <td class=""qty"">
            <div class=""quantity"">
                <a class=""quantity__minus""><span>-</span></a>
                <input name=""quantity"" type=""text"" disabled class=""quantity__input"" value=""1"">
                <a class=""quantity__plus""><span>+</span></a>
            </div></td>
            <td>178$</td>
            <td>
                <a href");
            WriteLiteral(@"=""#"" class=""btn btn-danger btn-sm"">
                    <i class=""fa fa-times""></i>
                </a>
            </td>
        </tr>
    </tbody>
</table>
<div class=""d-flex justify-content-end"">
    <h5>Total: <span class=""price text-success"">89$</span></h5>
</div>
<script>
    $('#form-modal').ready(() => {
        $('#close').click(() => {
            $('#form-modal').hide();
        })
    })

    $('.quantity__minus').click(() => {
        var data = Number($('.quantity__input').val());
        if (data > 1) {
            data -= 1;
            $('.quantity__input').val(data);
        }
    })
    $('.quantity__plus').click(() => {
        var data = Number($('.quantity__input').val());
        data +=1 ;
        $('.quantity__input').val(data);
    })
</script>























");
            WriteLiteral("\r\n");
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
