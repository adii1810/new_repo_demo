#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerIndex.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25169a78efc45a8fee35d01740a5b89d25b59c14"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Client_CustomerIndex), @"mvc.1.0.view", @"/Areas/Client/Views/Client/CustomerIndex.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25169a78efc45a8fee35d01740a5b89d25b59c14", @"/Areas/Client/Views/Client/CustomerIndex.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_Client_CustomerIndex : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Client.ViewModels.ShowProductViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerIndex.cshtml"
  
    ViewData["Title"] = "CustomerIndex";
    Layout = "~/Views/Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container-xxl py-5"">
    <div class=""container"">
        <div class=""text-center wow fadeInUp"" data-wow-delay=""0.1s"">
            <h5 class=""section-title ff-secondary text-center text-primary fw-normal"">Food Menu</h5>
            <h1 class=""mb-5"">Most Popular Items</h1>
        </div>
        <div class=""tab-class text-center wow fadeInUp"" data-wow-delay=""0.1s"">
            <ul class=""nav nav-pills d-inline-flex justify-content-center border-bottom mb-5"">
                <li class=""nav-item"">
                    <a class=""d-flex align-items-center text-start mx-3 ms-0 pb-3 "" data-bs-toggle=""pill"" id=""tab1"">
                        <i class=""fa fa-coffee fa-2x text-primary""></i>
                        <div class=""ps-3"">
                            <small class=""text-body"">Popular</small>
                            <h6 class=""mt-n1 mb-0"">Beverage</h6>
                        </div>
                    </a>
                </li>
                <li class=""nav-item"">
           ");
            WriteLiteral(@"         <a class=""d-flex align-items-center text-start mx-3 pb-3 active"" data-bs-toggle=""pill"" id=""tab2"">
                        <i class=""fa-solid fa-burger fa-2x""></i>
                        <div class=""ps-3"">
                            <small class=""text-body"">Special</small>
                            <h6 class=""mt-n1 mb-0"">Food</h6>
                        </div>
                    </a>
                </li>
                <li class=""nav-item"">
                    <a class=""d-flex align-items-center text-start mx-3 me-0 pb-3"" data-bs-toggle=""pill"" id=""tab3"">
                        <i class=""fa-solid fa-ice-cream fa-2x text-primary""></i>
                        <div class=""ps-3"">
                            <small class=""text-body"">Lovely</small>
                            <h6 class=""mt-n1 mb-0"">Desert</h6>
                        </div>
                    </a>
                </li>
            </ul>
            <div class=""tab-content"">
                <div id=""tab-1"" class=""");
            WriteLiteral("tab-pane fade show p-0 active\">\r\n                    <div class=\"row g-4\" id=\"product\">\r\n");
#nullable restore
#line 47 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerIndex.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-6\">\r\n                            <div class=\"d-flex align-items-center\">\r\n                                <img class=\"flex-shrink-0 img-fluid rounded\"");
            BeginWriteAttribute("src", " src=\"", 2594, "\"", 2613, 1);
#nullable restore
#line 51 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerIndex.cshtml"
WriteAttributeValue("", 2600, item.ImgLink, 2600, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2614, "\"", 2620, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""max-width: 3.5rem;"" >
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>");
#nullable restore
#line 54 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerIndex.cshtml"
                                         Write(item.Product_Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                        <span class=\"text-primary\">");
#nullable restore
#line 55 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerIndex.cshtml"
                                                              Write(item.Product_Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                    </h5>\r\n                                    <small class=\"fst-italic\">");
#nullable restore
#line 57 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerIndex.cshtml"
                                                         Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 61 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerIndex.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
                <div id=""tab-2"" class=""tab-pane fade show p-0"">
                    <div class=""row g-4"">
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 10445, "\"", 10451, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-2.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 11294, "\"", 11300, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-3.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 12143, "\"", 12149, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-4.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 12992, "\"", 12998, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-5.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 13841, "\"", 13847, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-6.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 14690, "\"", 14696, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-7.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 15539, "\"", 15545, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-8.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 16388, "\"", 16394, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id=""tab-3"" class=""tab-pane fade show p-0"">
                    <div class=""row g-4"">
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-1.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 17397, "\"", 17403, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-2.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 18246, "\"", 18252, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-3.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 19095, "\"", 19101, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-4.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 19944, "\"", 19950, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-5.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 20793, "\"", 20799, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-6.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 21642, "\"", 21648, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-7.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 22491, "\"", 22497, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""d-flex align-items-center"">
                                <img class=""flex-shrink-0 img-fluid rounded"" src=""img/menu-8.jpg""");
            BeginWriteAttribute("alt", " alt=\"", 23340, "\"", 23346, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""width: 80px;"">
                                <div class=""w-100 d-flex flex-column text-start ps-4"">
                                    <h5 class=""d-flex justify-content-between border-bottom pb-2"">
                                        <span>Chicken Burger</span>
                                        <span class=""text-primary"">$115</span>
                                    </h5>
                                    <small class=""fst-italic"">Ipsum ipsum clita erat amet dolor justo diam</small>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<My_Project.Areas.Client.ViewModels.ShowProductViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591