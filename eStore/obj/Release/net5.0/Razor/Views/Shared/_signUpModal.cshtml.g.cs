#pragma checksum "C:\Users\amitn\Documents\GitHub\eStore\eStore\Views\Shared\_signUpModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3630096d42effb5ccfbae06a3c590e0b19ba50b6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__signUpModal), @"mvc.1.0.view", @"/Views/Shared/_signUpModal.cshtml")]
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
#line 3 "C:\Users\amitn\Documents\GitHub\eStore\eStore\_ViewImports.cshtml"
using eStore.Shared.Data.Paging;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Views\_ViewImports.cshtml"
using eStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Views\_ViewImports.cshtml"
using eStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3630096d42effb5ccfbae06a3c590e0b19ba50b6", @"/Views/Shared/_signUpModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5a49e7469cad241f88c20b3ec28f827dad50346", @"/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff286e9e4391173d4c8cd0792f6d5da337863d8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__signUpModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade"" id=""signUpModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""myModalLabel""
     aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header text-center"">
                <h4 class=""modal-title w-100 font-weight-bold"">Sign up</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body mx-3"">
                <div class=""md-form mb-5"">
                    <i class=""fas fa-user prefix grey-text""></i>
                    <input type=""text"" id=""orangeForm-name"" class=""form-control validate"">
                    <label data-error=""wrong"" data-success=""right"" for=""orangeForm-name"">Name</label>
                </div>
                <div class=""md-form mb-5"">
                    <i class=""fas fa-envelope prefix grey-text""><");
            WriteLiteral(@"/i>
                    <input type=""email"" id=""orangeForm-email"" class=""form-control validate"">
                    <label data-error=""wrong"" data-success=""right"" for=""orangeForm-email"">Email</label>
                </div>

                <div class=""md-form mb-4"">
                    <i class=""fas fa-lock prefix grey-text""></i>
                    <input type=""password"" id=""orangeForm-pass"" class=""form-control validate"">
                    <label data-error=""wrong"" data-success=""right"" for=""orangeForm-pass"">Password</label>
                </div>
                <div class=""md-form mb-4"">
                    <i class=""fas fa-lock prefix grey-text""></i>
                    <input type=""password"" id=""orangeForm-passRe"" class=""form-control validate"">
                    <label data-error=""wrong"" data-success=""right"" for=""orangeForm-passRe"">Confirm password</label>
                </div>

            </div>
            <div class=""modal-footer d-flex justify-content-center"">
                ");
            WriteLiteral("<button class=\"btn btn-deep-orange btn-rounded\">Sign up</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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