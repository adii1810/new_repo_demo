#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22cedddb704748667d9b814ac549f3a988a72d9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Client_ShowOrders), @"mvc.1.0.view", @"/Areas/Client/Views/Client/ShowOrders.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22cedddb704748667d9b814ac549f3a988a72d9d", @"/Areas/Client/Views/Client/ShowOrders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_Client_ShowOrders : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<My_Project.Areas.Client.ViewModels.ShowOrderViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
  
    ViewData["Title"] = "ShowOrders";
    Layout = "~/Views/Shared/_CustomerLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .list-group {
        border-color: #D0D5DC !important;
    }

        .list-group .list-group-item {
            border-color: #D0D5DC !important;
        }

    h1, h2, h3, h4, h5, h6 {
        font-weight: 500 !important;
    }

    .text-orange {
        color: #EC9532 !important;
    }

    .text-carbon {
        color: #222C3A !important;
    }

    .text-pebble {
        color: #79879A !important;
    }

    .text-gray {
        color: #A2ABB9 !important;
    }

    .text-cloud {
        color: #D0D5DC !important;
    }

    .text-blue {
        color: #49AED0 !important;
    }

    .text-gray {
        color: #A2ABB9 !important;
    }

    .text-pale-sky {
        color: #A2ABB9 !important;
    }

    .bg-black {
        background: #111822 !important;
    }

    .bg-snow {
        background: #F9FAFB !important;
    }

    .bg-fog {
        background: #F0F2F5 !important;
    }

    .bb1-cloud {
        border-bottom: 1px solid #");
            WriteLiteral(@"D0D5DC;
    }

    .fs-14 {
        font-size: 14px !important;
    }

    .fs-22 {
        font-size: 22px !important;
    }



    .btn-primary {
        background: #C62931;
        border-color: #C62931;
        cursor: pointer;
    }

        .btn-primary:hover {
            background: #d94950;
            border-color: #d94950;
        }

    .btn-secondary {
        background: #FFFFFF !important;
        color: #354050 !important;
        border-color: #D0D5DC !important;
        cursor: pointer;
    }

        .btn-secondary:hover {
            color: #354050 !important;
            background: #F9FAFB !important;
        }

        .btn-secondary:active {
            color: #79879A !important;
            background: #F0F2F5 !important;
        }

        .btn-secondary:focus {
            color: #79879A !important;
            background: #F0F2F5 !important;
            outline: 0 !important;
        }



    .fs-18 {
        font-size: 18px !impor");
            WriteLiteral(@"tant;
    }

    .fs-22 {
        font-size: 22px !important;
    }

    .bg-snow {
        background: #F9FAFB !important;
    }

    .card {
        border-color: #D0D5DC !important;
    }

    .text-pebble {
        color: #79879A !important;
    }

    .text-charcoal {
        color: #354050 !important;
    }

    .bottom-drawer {
        position: fixed;
        bottom: 56px;
        width: 100%;
        border-top: 1px solid #D0D5DC;
    }

    .bg-white {
        background: #FFFFFF !important;
    }

    .list-group {
        border-color: #D0D5DC !important;
    }

    .list-group-item {
        border-color: #D0D5DC !important;
    }

    .text-red {
        color: #C62931 !important;
    }

    .text-green {
        color: #00A362 !important;
    }

    .text-link-blue {
        color: #3373cc !important;
    }

    .form-control {
        background: #F9FAFB;
        border-color: #D0D5DC !important;
    }

    .bd-2-cloud {
        borde");
            WriteLiteral(@"r: 2px dashed #D0D5DC;
    }

    .b-1-green {
        border: 2px solid #00A362 !important;
    }

    .br-8 {
        border-radius: 5px;
    }


    /*=======================ProgressBar===================================================*/

    ");
            WriteLiteral(@"@charset ""UTF-8"";

    .multi-steps > li.is-active ~ li:before, .multi-steps > li.is-active:before {
        content: counter(stepNum);
        font-family: inherit;
        font-weight: 700;
    }

    .multi-steps > li.is-active ~ li:after, .multi-steps > li.is-active:after {
        background-color: #e1e1e1;
    }

    .multi-steps {
        display: table;
        table-layout: fixed;
        width: 100%;
    }

        .multi-steps > li {
            counter-increment: stepNum;
            text-align: center;
            display: table-cell;
            position: relative;
            color: #027f00;
        }

            .multi-steps > li:before {
                content: """";
                content: ""✓;"";
                content: ""𐀃"";
                content: ""𐀄"";
                content: ""✓"";
                display: block;
                margin: 0 auto 4px;
                background-color: #027f00;
                width: 36px;
                height: 36px;
");
            WriteLiteral(@"                line-height: 32px;
                text-align: center;
                font-weight: bold;
                border-width: 2px;
                border-style: solid;
                border-color: #027f00;
                border-radius: 50%;
                color: white;
            }

            .multi-steps > li:last-child:after {
                display: none;
            }

            .multi-steps > li.is-active:before {
                background-color: #fff;
                border-color: #027f00;
                color: #027f00;
                animation: pulse 2s infinite;
            }

            .multi-steps > li.is-active ~ li {
                color: #808080;
            }

                .multi-steps > li.is-active ~ li:before {
                    background-color: #e1e1e1;
                    border-color: #e1e1e1;
                    color: #808080;
                }

    .is-complete {
        background: linear-gradient(to right, #027f00 50%, #e1");
            WriteLiteral("e1e1 50%);\r\n        background-size: 200% 100%;\r\n        background-position: right bottom;\r\n        transition: all 0.5s ease-out;\r\n    }\r\n\r\n    ");
            WriteLiteral("@keyframes pulse {\r\n        0% {\r\n            box-shadow: 0 0 0 0 #027f0070;\r\n        }\r\n\r\n        100% {\r\n            box-shadow: 0 0 0 10px #027f0000;\r\n        }\r\n    }\r\n\r\n    ");
            WriteLiteral(@"@keyframes nextStep {
        0% {
            width: 0%;
        }

        100% {
            width: 100%;
        }
    }

    .progress-bar {
        cursor: pointer;
        user-select: none;
    }

    .progress-bar {
        background-color: #e1e1e1;
        height: 7px;
        overflow: hidden;
        position: absolute;
        left: 50%;
        bottom: calc(50% + 7px);
        width: 100%;
        z-index: -1;
    }

    .progress-bar--success {
        background-color: #027f00;
    }

    .progress-bar__bar {
        background-color: #e1e1e1;
        bottom: 0;
        left: 0;
        position: absolute;
        right: 0;
        top: 0;
        transition: all 500ms ease-out;
    }



    /*=======================ProgressBar===================================================*/

</style>





<div class=""container mt-3 mt-md-5"">
    <h2 class=""text-charcoal hidden-sm-down"">Your Orders</h2>
");
#nullable restore
#line 327 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""row"">
            <div class=""col-12"">
                <div class=""list-group mb-5"">
                    <div class=""list-group-item p-3 bg-snow"" style=""position: relative;"">
                        <div class=""row w-100 no-gutters"">
                            <div class=""col-6 col-md"">
                                <h6 class=""text-charcoal mb-0 w-100"">Order Number</h6>
                                <a");
            BeginWriteAttribute("href", " href=\"", 7338, "\"", 7345, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"text-pebble mb-0 w-100 mb-2 mb-md-0\">");
#nullable restore
#line 336 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
                                                                                  Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                            </div>
                            <div class=""col-6 col-md"">
                                <h6 class=""text-charcoal mb-0 w-100"">Date</h6>
                                <p class=""text-pebble mb-0 w-100 mb-2 mb-md-0"">");
#nullable restore
#line 340 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
                                                                          Write(item.OrderDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                            <div class=""col-6 col-md"">
                                <h6 class=""text-charcoal mb-0 w-100"">Total</h6>
                                <p class=""text-pebble mb-0 w-100 mb-2 mb-md-0"">");
#nullable restore
#line 344 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
                                                                          Write(item.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                            <div class=\"col-12 col-md-3\">\r\n                                <a class=\"btn btn-primary w-100\"");
            BeginWriteAttribute("onclick", " onclick=\"", 8117, "\"", 8244, 4);
            WriteAttributeValue("", 8127, "showInPopup(\'", 8127, 13, true);
#nullable restore
#line 348 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 8140, Url.Action("ShowOrderDetail","Client",new {id = item.OrderId},Context.Request.Scheme), 8140, 86, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8226, "\',\'Order", 8226, 8, true);
            WriteAttributeValue(" ", 8234, "Details\')", 8235, 10, true);
            EndWriteAttribute();
            WriteLiteral(@" >View Order</a>
                            </div>
                        </div>

                    </div>
                    <div class=""list-group-item p-3 bg-white"">
                        <div class=""row w-100 no-gutters"">
                            <div class=""col-12 col-md-9 pr-0 pr-md-3"">
                                <div class=""alert p-2 alert-success w-100 mb-0 sec_status""");
            BeginWriteAttribute("id", " id=\"", 8647, "\"", 8679, 2);
            WriteAttributeValue("", 8652, "sectionStatus_", 8652, 14, true);
#nullable restore
#line 356 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 8666, item.OrderId, 8666, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n\r\n                                    <ul class=\"list-unstyled multi-steps\">\r\n                                        <li");
            BeginWriteAttribute("id", " id=\"", 8806, "\"", 8831, 2);
            WriteAttributeValue("", 8811, "step-1_", 8811, 7, true);
#nullable restore
#line 360 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 8818, item.OrderId, 8818, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class="" is-active"">
                                            Pending<div class=""progress-bar progress-bar--success"">
                                                <div class=""progress-bar__bar""></div>
                                            </div>
                                        </li>
                                        <li");
            BeginWriteAttribute("id", " id=\"", 9184, "\"", 9209, 2);
            WriteAttributeValue("", 9189, "step-2_", 9189, 7, true);
#nullable restore
#line 365 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 9196, item.OrderId, 9196, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                            Approved<div class=""progress-bar progress-bar--success"">
                                                <div class=""progress-bar__bar""></div>
                                            </div>
                                        </li>
                                        <li");
            BeginWriteAttribute("id", " id=\"", 9544, "\"", 9569, 2);
            WriteAttributeValue("", 9549, "step-3_", 9549, 7, true);
#nullable restore
#line 370 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 9556, item.OrderId, 9556, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                            Order Taken<div class=""progress-bar progress-bar--success"">
                                                <div class=""progress-bar__bar""></div>
                                            </div>
                                        </li>
                                        <li");
            BeginWriteAttribute("id", " id=\"", 9907, "\"", 9932, 2);
            WriteAttributeValue("", 9912, "step-4_", 9912, 7, true);
#nullable restore
#line 375 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 9919, item.OrderId, 9919, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                            Order On the way<div class=""progress-bar progress-bar--success"">
                                                <div class=""progress-bar__bar""></div>
                                            </div>
                                        </li>
                                        <li");
            BeginWriteAttribute("id", " id=\"", 10275, "\"", 10300, 2);
            WriteAttributeValue("", 10280, "step-5_", 10280, 7, true);
#nullable restore
#line 380 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 10287, item.OrderId, 10287, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">Delivered</li>
                                    </ul>



                                </div>
                            </div>
                            <div class=""col-12 col-md-3"">
                                <a class=""btn btn-secondary w-100 mb-2""");
            BeginWriteAttribute("onclick", " onclick=\"", 10573, "\"", 10622, 5);
            WriteAttributeValue("", 10583, "showUp(", 10583, 7, true);
#nullable restore
#line 388 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 10590, item.OrderStatus, 10590, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10607, ",", 10607, 1, true);
#nullable restore
#line 388 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
WriteAttributeValue("", 10608, item.OrderId, 10608, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10621, ")", 10621, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Track Shipment</a>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n\r\n\r\n        </div>\r\n");
#nullable restore
#line 397 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ShowOrders.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $('.display-3').html(""Order History"");
        $(document).ready(() => {
            $('.sec_status').hide();
        })

        const showUp = (status, ordid) => {
            $('#sectionStatus_' + ordid).slideToggle('slow');
            if (status == 0) {
                $('#step-1_' + ordid).addClass('is-active');
                $('#step-2_' + ordid).removeClass('is-active');
                $('#step-3_' + ordid).removeClass('is-active');
                $('#step-4_' + ordid).removeClass('is-active');
                $('#step-5_' + ordid).removeClass('is-active');
            }
            else if (status == 1) {
                $('#step-2_' + ordid).addClass('is-active');
                $('#step-1_' + ordid).removeClass('is-active');
                $('#step-3_' + ordid).removeClass('is-active');
                $('#step-4_' + ordid).removeClass('is-active');
                $('#step-5_' + ordid).removeClass('is-active');
            }
            else if (s");
                WriteLiteral(@"tatus == 2) {
                $('#step-3_' + ordid).addClass('is-active');
                $('#step-1_' + ordid).removeClass('is-active');
                $('#step-2_' + ordid).removeClass('is-active');
                $('#step-4_' + ordid).removeClass('is-active');
                $('#step-5_' + ordid).removeClass('is-active');
            }
            else if (status == 3) {
                $('#step-4_' + ordid).addClass('is-active');
                $('#step-1_' + ordid).removeClass('is-active');
                $('#step-2_' + ordid).removeClass('is-active');
                $('#step-3_' + ordid).removeClass('is-active');
                $('#step-5_' + ordid).removeClass('is-active');
            }
            else if (status == 4) {
                $('#step-5_' + ordid).addClass('is-active');
                $('#step-1_' + ordid).removeClass('is-active');
                $('#step-2_' + ordid).removeClass('is-active');
                $('#step-3_' + ordid).removeClass('is-active');
    ");
                WriteLiteral("            $(\'#step-4_\' + ordid).removeClass(\'is-active\');\r\n            }\r\n\r\n        }\r\n\r\n        \r\n    </script>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<My_Project.Areas.Client.ViewModels.ShowOrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
