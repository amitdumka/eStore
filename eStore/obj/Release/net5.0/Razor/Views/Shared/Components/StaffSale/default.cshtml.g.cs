#pragma checksum "C:\Users\amitn\Documents\GitHub\eStore\eStore\Views\Shared\Components\StaffSale\default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "863ae5da4ee21fc8a6eb2b4fa4a5ea5c63e0a216"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_StaffSale_default), @"mvc.1.0.view", @"/Views/Shared/Components/StaffSale/default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"863ae5da4ee21fc8a6eb2b4fa4a5ea5c63e0a216", @"/Views/Shared/Components/StaffSale/default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5a49e7469cad241f88c20b3ec28f827dad50346", @"/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff286e9e4391173d4c8cd0792f6d5da337863d8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_StaffSale_default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eStore.Shared.ViewModels.ChartJSVC.ChartJsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""chart-container"" width=""600"" height=""400"">
    <canvas id=""staffSale""></canvas>
</div>

<script>
    document.addEventListener('DOMContentLoaded', (event) => {

        var ctx = document.getElementById('staffSale');
        var myChart = new Chart(ctx, ");
#nullable restore
#line 11 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Views\Shared\Components\StaffSale\default.cshtml"
                                Write(Html.Raw(Model.ChartJson));

#line default
#line hidden
#nullable disable
            WriteLiteral(" );\r\n\r\n    });\r\n</script> ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eStore.Shared.ViewModels.ChartJSVC.ChartJsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
