#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9a75a4ed7738068e1a8909c2c2ff5fef0f192df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Restaurant_Views_Restaurant_UpdateImages), @"mvc.1.0.view", @"/Areas/Restaurant/Views/Restaurant/UpdateImages.cshtml")]
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
#line 1 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\_ViewImports.cshtml"
using My_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\_ViewImports.cshtml"
using My_Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9a75a4ed7738068e1a8909c2c2ff5fef0f192df", @"/Areas/Restaurant/Views/Restaurant/UpdateImages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Restaurant/Views/_ViewImports.cshtml")]
    public class Areas_Restaurant_Views_Restaurant_UpdateImages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Restaurant.ViewModels.ImageViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary text-white btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddImage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Restaurant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Restaurant", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
  
    ViewData["Title"] = "UpdateImages";
    Layout = "~/Views/Shared/_RestaurantLayout.cshtml";
    var prodid = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9a75a4ed7738068e1a8909c2c2ff5fef0f192df5122", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/css/bootstrap.min.css"" integrity=""sha384-Vkoo8x4CGsO3+Hhxv8T/Q5PaXtkKtu6ug5TOeNV6gBiFeWPGFN9MuhOf23Q9Ifjh"" crossorigin=""anonymous"">

    <style>
        #showImg {
            height: 500px;
            width: 600px;
        }

        .carousel-inner {
            border-radius: 10px;
        }

            .carousel-inner div img {
                height: 500px;
                width: 600px;
            }
    </style>


    <script src=""https://code.jquery.com/jquery-3.4.1.slim.min.js"" integrity=""sha384-J6qa4849blE2+poT4WnyKhv5vZF5SrPo0iEjwBvKU7imGFAV0wwj1yYfoRSJoZ+n"" crossorigin=""anonymous""></script>
    <script src=""https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"" integrity=""sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo"" crossorigin=""anonymous""></script>
    <script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.4.1/dist/js/bootstrap.min.js"" integrity=""sha");
                WriteLiteral(@"384-wfSDF2E50Y2D1uUdj0O3uMBJnjuUD4Ih7YwaYd1iqfktj0Uod8GCExl3Og8ifwB6"" crossorigin=""anonymous""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"" integrity=""sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
    <script>
        function DeleteImage(prodid) {
            alert(prodid);
            var elem = $("".active"").attr(""id"");
            console.log(elem);
            $.ajax({
                url: location2 + 'DeleteImage',
                type: ""Post"",
                data: { Id: elem },
                success: function (response) {
                    window.location = location2+""UpdateImages?Prodid=""+prodid;
                }
            })
        }

    </script>
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
            WriteLiteral("\r\n<div class=\"py-2\">\r\n    <label class=\"text-blue\"><i class=\"fa-brands fa-opencart\"> Update Images</i></label>\r\n</div>\r\n<div id=\"showImg\" class=\" container carousel slide \" data-ride=\"carousel\">\r\n\r\n    <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 56 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
          var i = 0;

        

#line default
#line hidden
#nullable disable
#nullable restore
#line 59 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
         foreach (var item in Model)
        {
            if (i == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"carousel-item active\" data-interval=\"100000\"");
            BeginWriteAttribute("id", " id=\"", 2524, "\"", 2540, 1);
#nullable restore
#line 63 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
WriteAttributeValue("", 2529, item.ImgId, 2529, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 2568, "\"", 2587, 1);
#nullable restore
#line 64 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
WriteAttributeValue("", 2574, item.imgLink, 2574, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2588, "\"", 2596, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n");
#nullable restore
#line 66 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"carousel-item\" data-interval=\"100000\"");
            BeginWriteAttribute("id", " id=\"", 2737, "\"", 2753, 1);
#nullable restore
#line 69 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
WriteAttributeValue("", 2742, item.ImgId, 2742, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 2781, "\"", 2800, 1);
#nullable restore
#line 70 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
WriteAttributeValue("", 2787, item.imgLink, 2787, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2801, "\"", 2809, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n");
#nullable restore
#line 72 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
            }
            i++;
            prodid = item.ProdId;
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>

    <a class=""carousel-control-prev"" href=""#showImg"" role=""button"" data-slide=""prev"">
        <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Previous</span>
    </a>
    <a class=""carousel-control-next"" href=""#showImg"" role=""button"" data-slide=""next"">
        <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
        <span class=""sr-only"">Next</span>
    </a>
    <div class=""py-2"">
        <button class=""btn btn-danger text-white btn-block""");
            BeginWriteAttribute("onclick", " onclick=\"", 3453, "\"", 3483, 3);
            WriteAttributeValue("", 3463, "DeleteImage(", 3463, 12, true);
#nullable restore
#line 88 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
WriteAttributeValue("", 3475, prodid, 3475, 7, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3482, ")", 3482, 1, true);
            EndWriteAttribute();
            WriteLiteral("> Delete Image</button>\r\n    </div>\r\n    <div class=\"py-1\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9a75a4ed7738068e1a8909c2c2ff5fef0f192df12667", async() => {
                WriteLiteral(" Add Image");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-prodId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 91 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Restaurant\Views\Restaurant\UpdateImages.cshtml"
                                                              WriteLiteral(prodid);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["prodId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-prodId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["prodId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<My_Project.Areas.Restaurant.ViewModels.ImageViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591