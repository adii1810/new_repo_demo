#pragma checksum "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1ed88662a50c3810fd772f4bfe67aefd095fa418"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Client_Views_Client_CustomerLogin), @"mvc.1.0.view", @"/Areas/Client/Views/Client/CustomerLogin.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ed88662a50c3810fd772f4bfe67aefd095fa418", @"/Areas/Client/Views/Client/CustomerLogin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2ab576de6d832be0cadb753ce7ff29ea9bd490f7", @"/Areas/Client/Views/_ViewImports.cshtml")]
    public class Areas_Client_Views_Client_CustomerLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerLogin.cshtml"
  
    ViewData["Title"] = "CustomerLogin";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    html,
    body {
        height: 100%;
    }

    .global-container {
        height: 100%;
        display: flex;
        align-items: center;
        justify-content: center;
        
        background-color: transparent !important;
        border: 0px !important
    }

    form {
        padding-top: 10px;
        font-size: 14px;
        margin-top: 30px;
    }

    .card-title {
        font-weight: 300;
    }

    .btn {
        font-size: 14px;
        margin-top: 20px;
    }

    .login-form {
        width: 330px;
        margin: 20px;
    }

    .sign-up {
        text-align: center;
        padding: 20px 0 0;
    }

    .alert {
        margin-bottom: -30px;
        font-size: 13px;
        margin-top: 20px;
    }
    .modal-content {
        background-color: transparent !important;
        border: 0px !important
    }

    .modal-header {
        border: 0px !important
    }
    .modal.fade .modal-dialog {
        -webkit-trans");
            WriteLiteral(@"form: translate(0);
        -moz-transform: translate(0);
        transform: translate(0);
    }
</style>

<div class=""global-container"">
    <div class=""card login-form"">
        <div class=""card-body"">
            <h3 class=""card-title text-center"">Log in to Codepen</h3>
            <div class=""card-text"">
                <!--
                <div class=""alert alert-danger alert-dismissible fade show"" role=""alert"">Incorrect username or password.</div> -->
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1ed88662a50c3810fd772f4bfe67aefd095fa4185524", async() => {
                WriteLiteral(@"
                    <!-- to error: add class ""has-danger"" -->
                    <div class=""form-group"">
                        <label for=""exampleInputEmail1"">Email address</label>
                        <input type=""text"" name=""Uname"" class=""form-control form-control-sm"" id=""exampleInputEmail1"" aria-describedby=""emailHelp"">
                    </div>
                    <div class=""form-group"">
                        <label for=""exampleInputPassword1"">Password</label>
                        <a href=""#"" style=""float:right;font-size:12px;"">Forgot password?</a>
                        <input type=""password"" name=""Pass"" class=""form-control form-control-sm"" id=""exampleInputPassword1"">
                    </div>
                    <button class=""btn btn-primary btn-block"" id=""btnLogin"">Sign in</button>
                    <button class=""btn btn-dark btn-block text-white"" id=""btnclose"">Close </button>

                    <div class=""sign-up"">
                        Don't have an account? <");
                WriteLiteral("a");
                BeginWriteAttribute("onclick", " onclick=\"", 2631, "\"", 2743, 4);
                WriteAttributeValue("", 2641, "showInPopup(\'", 2641, 13, true);
#nullable restore
#line 90 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerLogin.cshtml"
WriteAttributeValue("", 2654, Url.Action("CustomerReg","Client",null,Context.Request.Scheme), 2654, 63, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2717, "\',\'Customer", 2717, 11, true);
                WriteAttributeValue(" ", 2728, "Registration\')", 2729, 15, true);
                EndWriteAttribute();
                WriteLiteral(" class=\"text-blue\">Create One</a>\r\n                    </div>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>
<script>
    $(""#btnclose"").click(() => {
        $(""#form-modal"").hide();
    })

    $('#btnLogin').click(() => {
        var formData = $('form').serializeArray();
        event.preventDefault();
        $.ajax({
            url:location3 + ""CustomerLogin"",
            type: ""Post"",
            data: formData,
            success: function (response) {
                console.log(""response"");
                if (response != """")
                {
                    alert(""Success"");
                    window.location.href = location3 + ""CustomerIndex"";
                }
               else
                   showInPopup('");
#nullable restore
#line 117 "E:\AdityaBackup\Demo\Demo_Project1\new_repo_demo\My_Project\Areas\Client\Views\Client\CustomerLogin.cshtml"
                           Write(Url.Action("CustomerLogin","Client",null,Context.Request.Scheme));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"','Customer Login')
            },
             failure: function (response) {
                console.log(""failure"");
                alert(response.responseText);
            },
            error: function (response) {
                alert(""error"");
                alert(response.responseText);
            }
        })
    })
</script>");
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
