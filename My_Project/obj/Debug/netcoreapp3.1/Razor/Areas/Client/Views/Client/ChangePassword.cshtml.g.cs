#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ChangePassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a9b31c07947a9bd8e4f150938c70eb62d4b156e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Client_ChangePassword), @"mvc.1.0.view", @"/Areas/Client/Views/Client/ChangePassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a9b31c07947a9bd8e4f150938c70eb62d4b156e", @"/Areas/Client/Views/Client/ChangePassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_Client_ChangePassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Client", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Client", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChangePassword", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\ChangePassword.cshtml"
  
    ViewData["Title"] = "ChangePassword";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>

    .form-control {
        border-radius: 5px;
    }

    .btn {
        border-radius: 5px;
    }
</style>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"" integrity=""sha512-894YE6QWD5I59HgZOGReFYm4dnWc1Qt5NtvYSaNcOP+u1T9qYdvdihz0PPSiiqn/+/3e7Jo4EaG7TubfWGUrMQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>



<div class=""container "">

    <div class=""py-4 d-flex justify-content-center"">
        <label class=""text-blue""><i class=""fas fa-hamburger""> Change Password</i></label>
    </div>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a9b31c07947a9bd8e4f150938c70eb62d4b156e5476", async() => {
                WriteLiteral(@"
        <div class=""row  d-flex justify-content-center"">
            <div class=""col-md-4"">
                <div class=""form-group"">
                    <input type=""password"" class=""form-control"" placeholder=""Previous Password"" id=""prepass"" />
                    <span class=""text-danger"" id=""prepassValidator""></span>
                </div>
                <div class=""form-group"">
                    <input type=""password"" name=""pass"" class=""form-control"" placeholder=""Password"" id=""pass1"" />
                    <span class=""text-danger""></span>
                </div>

                <div class=""form-group"">
                    <input type=""password"" class=""form-control"" placeholder=""Re-enter Password"" id=""pass2"" />
                    <span class=""text-success"" id=""SuccessValidator""></span>
                </div>
                <div class=""form-group"">
                    <input type=""button"" value=""Send"" disabled class=""btn btn-success btn-block"" id=""send"" />
                </div>
   ");
                WriteLiteral(@"             <div class=""form-group"">
                    <input type=""text"" class=""form-control"" placeholder=""Security code"" id=""code"" />
                    <span class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <input type=""submit"" value=""Change Password"" disabled class=""btn btn-success btn-block"" id=""changePass"" />
                </div>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<div class=""form-group"">
    <button value=""Close"" class=""btn btn-dark btn-block"" id=""btnclose"">Close</button>
</div>
<script>
    $('#pass2').keyup(() => {
        var pass = document.getElementById(""pass1"").value;
        var pass2 = document.getElementById(""pass2"").value;

        if (pass == pass2) {
            $('#send').removeAttr('disabled');
            console.log(""pass same"");
        }
        else {
            $('#send').attr('disabled', 'disabled');
            console.log(pass2);
        }

    })
    $('#send').click(() => {

        var pass0 = document.getElementById(""prepass"").value;

        $.ajax({
            url: location3 + ""code"",
            type: ""Post"",
            data: { prepass: pass0 },
            success: function (response) {
                if (response != ""false"") {
                    console.log(typeof response);
                    var code = Number(response);
                    console.log(code);
                    console.l");
            WriteLiteral(@"og(typeof code);
                    $('#SuccessValidator').html(""Security Code is sended to your Registered email"");

                    $(""#code"").keyup(() => {
                        var inputedCode = document.getElementById(""code"").value;
                        if (code == inputedCode) {
                            $('#changePass').removeAttr('disabled');
                        }
                        else {
                            $('#changePass').attr('disabled', 'disabled');
                        }
                    })
                }
                else {
                    $('#prepassValidator').html(""Previous Password is Wrong"");
                }
            }
        })
    })

    $('#Checkout').hide();
    $('#close').hide();
    $('#btnclose').click(() => {
        $('#form-modal').hide();
        $('#Checkout').show();
        $('#close').show();
    })

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
