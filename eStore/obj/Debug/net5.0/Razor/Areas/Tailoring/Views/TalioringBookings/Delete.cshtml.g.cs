#pragma checksum "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "762e1d9f47d4e916b4f5402c9dd1f04b7200a8b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Tailoring_Views_TalioringBookings_Delete), @"mvc.1.0.view", @"/Areas/Tailoring/Views/TalioringBookings/Delete.cshtml")]
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
#line 1 "C:\Users\amitn\Documents\GitHub\eStore\eStore\_ViewImports.cshtml"
using eStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\amitn\Documents\GitHub\eStore\eStore\_ViewImports.cshtml"
using eStore.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\amitn\Documents\GitHub\eStore\eStore\_ViewImports.cshtml"
using eStore.Shared.Data.Paging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"762e1d9f47d4e916b4f5402c9dd1f04b7200a8b7", @"/Areas/Tailoring/Views/TalioringBookings/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5a49e7469cad241f88c20b3ec28f827dad50346", @"/_ViewImports.cshtml")]
    public class Areas_Tailoring_Views_TalioringBookings_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eStore.Shared.Models.Tailoring.TalioringBooking>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>TalioringBooking</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 14 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BookingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BookingDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 20 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CustName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CustName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 26 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DeliveryDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 29 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DeliveryDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 32 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TryDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 35 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TryDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 38 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BookingSlipNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 41 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BookingSlipNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 44 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 47 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TotalAmount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 50 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.TotalQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 53 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.TotalQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 56 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ShirtQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 59 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ShirtQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 62 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.ShirtPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 65 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.ShirtPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 68 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PantQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 71 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PantQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 74 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PantPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 77 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PantPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 80 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CoatQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 83 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CoatQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 86 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CoatPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 89 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CoatPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 92 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.KurtaQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 95 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.KurtaQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 98 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.KurtaPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 101 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.KurtaPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 104 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BundiQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 107 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BundiQty));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 110 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.BundiPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 113 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.BundiPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 116 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Others));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 119 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Others));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 122 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.OthersPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 125 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.OthersPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 128 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDelivered));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 131 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsDelivered));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 134 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Store));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 137 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Store.StoreId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 140 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 143 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 146 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.EntryStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 149 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.EntryStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 152 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsReadOnly));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 155 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsReadOnly));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "762e1d9f47d4e916b4f5402c9dd1f04b7200a8b721114", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "762e1d9f47d4e916b4f5402c9dd1f04b7200a8b721381", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 160 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Tailoring\Views\TalioringBookings\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.TalioringBookingId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> \r\n\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eStore.Shared.Models.Tailoring.TalioringBooking> Html { get; private set; }
    }
}
#pragma warning restore 1591
