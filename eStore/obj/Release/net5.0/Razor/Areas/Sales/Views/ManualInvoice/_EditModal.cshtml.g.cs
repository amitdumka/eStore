#pragma checksum "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Sales\Views\ManualInvoice\_EditModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb8b66f19f626edea31346234e9eb86a7698ea5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Sales_Views_ManualInvoice__EditModal), @"mvc.1.0.view", @"/Areas/Sales/Views/ManualInvoice/_EditModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb8b66f19f626edea31346234e9eb86a7698ea5c", @"/Areas/Sales/Views/ManualInvoice/_EditModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5a49e7469cad241f88c20b3ec28f827dad50346", @"/_ViewImports.cshtml")]
    public class Areas_Sales_Views_ManualInvoice__EditModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("editInvoiceForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade"" id=""editInvoiceModal"">
    <div class=""modal-dialog modal-lg"" style="" width: 900px !important;"">
        <div class=""modal-content"">
            <div class=""modal-header table-primary"">
                <h4 class=""text-success"">Edit Invoice</h4> <a href=""#"" class=""close"" data-dismiss=""modal"">&times;</a>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb8b66f19f626edea31346234e9eb86a7698ea5c4337", async() => {
                WriteLiteral("\r\n                <div class=\"modal-body\">\r\n");
                WriteLiteral(@"                    <h5 style=""color:#ff6347"">Customer Details</h5>
                    <hr />
                    <div class=""form-row"">
                        <table class=""table table-active"">
                            <tr>
                                <th>CustomerName</th>
");
                WriteLiteral("                                <th>InvoiceNo</th>\r\n                                <th>Sale Date</th>\r\n                            </tr>\r\n                            <tr>\r\n                                <td><input readonly");
                BeginWriteAttribute("value", " value=\"", 1074, "\"", 1082, 0);
                EndWriteAttribute();
                WriteLiteral(" type=\"text\" id=\"eName\" name=\"eName\" placeholder=\" Name\" class=\"form-control\" /></td>\r\n");
                WriteLiteral("                                <td><input readonly");
                BeginWriteAttribute("value", " value=\"", 1381, "\"", 1389, 0);
                EndWriteAttribute();
                WriteLiteral(" type=\"text\" id=\"invoiceNo\" name=\"invoiceNo\" placeholder=\" invoiceNo\" class=\"form-control\" /></td>\r\n                                <td><input type=\"date\" id=\"eOnDate\" name=\"eOnDate\" class=\"form-control\"");
                BeginWriteAttribute("value", " value=\"", 1593, "\"", 1621, 1);
#nullable restore
#line 25 "C:\Users\amitn\Documents\GitHub\eStore\eStore\Areas\Sales\Views\ManualInvoice\_EditModal.cshtml"
WriteAttributeValue("", 1601, DateTime.Today.Date, 1601, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" /></td>\r\n                            </tr>\r\n\r\n                        </table>\r\n                    </div>\r\n");
                WriteLiteral(@"                    <h5 style=""margin-top:10px;color:#ff6347"">Bill Details</h5>
                    <hr />
                    <div class=""form-row"">
                        <table class=""table table-active table-sm"">
                            <tr>
                                <th>Total Amount</th>
                                <th>Total Qty</th>
                                <th>Total Discount</th>
                                <th>NoofItem</th>
                            </tr>
                            <tr>
                                <td><input type=""number"" readonly value=""0"" id=""eTotalAmount"" class=""form-control"" /></td>
                                <td><input type=""number"" readonly value=""0"" id=""eTotalQty"" class=""form-control"" /></td>
                                <td><input type=""number"" readonly value=""0"" id=""eTotalDiscount"" class=""form-control"" /></td>
                                <td><input type=""number"" readonly value=""0"" id=""eTotalItem"" class=""form-control"" ");
                WriteLiteral("/></td>\r\n                            </tr>\r\n                        </table>\r\n\r\n                    </div>\r\n\r\n");
                WriteLiteral(@"                    <h5 style=""margin-top:10px;color:#ff6347"">Item(s)</h5>
                    <hr />
                    <div>
                        <table>
                            <tr>
                                <th>Salesman</th>
                                <th>BarCode</th>
                                <th></th>
                                <th>ProductName</th>
                                <th>Price</th>
                                <th>Qty</th>

                            </tr>
                            <tr>
                                <td>
                                    <select id=""salesManEdit"" name=""saleManEdit"" class=""form-control"">
                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb8b66f19f626edea31346234e9eb86a7698ea5c8518", async() => {
                    WriteLiteral("Select Salesman");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                    </select>
                                </td>
                                <td>
                                    <input type=""text"" id=""eBarCode"" name=""eBarCode"" placeholder=""BarCode"" class=""form-control"" />
                                </td>
                                <td>
                                    <a id=""getEBarCode"" class=""btn btn-sm btn-outline-success"">Get</a>
                                </td>
                                <td><input type=""text"" id=""eProductName"" name=""eProductName"" placeholder=""Product Name"" class=""form-control"" /></td>
                                <td> <input type=""number"" id=""ePrice"" name=""ePrice"" placeholder=""Product Price"" class=""form-control"" /></td>
                                <td>  <input type=""number"" id=""eQuantity"" name=""eQuantity"" placeholder=""Quantity"" class=""form-control"" /></td>

                                <td>
                                    <input type=""hidden"" id=""units"" na");
                WriteLiteral(@"me=""units"" />
                                    <a id=""saveToList"" name=""saveToList"" class=""btn btn-sm btn-outline-primary"">Save</a>

                                </td>
                            </tr>
                        </table>
                        <table id=""editDetailsTable"" class=""table"">
                            <thead>
                                <tr>
                                    <th style=""width:5%"">SM</th>
                                    <th style=""width:20%"">BarCode</th>
                                    <th style=""width:25%"">Product</th>
                                    <th style=""width:15%"">Unit Price</th>
                                    <th style=""width:15%"">Quantity</th>
                                    <th style=""width:15%"">Amount</th>
                                    <th style=""width:10%"">Units</th>
                                    <th></th>
                                </tr>
                            </thead>
          ");
                WriteLiteral(@"                  <tbody></tbody>
                        </table>
                    </div>
                    <hr />
                    <h5 class=""purple-text""> Payment Details</h5>
                    <hr />
                    <div>
                        <table class=""table table-bordered"">
                            <tr>
                                <th>Cash Amount</th>
                                <th>Card Amount</th>
                                <th>CardType</th>
                                <th>CardNo</th>
                                <th>Auth Code</th>
                            </tr>
                            <tr>
                                <td><input type=""text"" id=""eCashAmt"" name=""eCashAmt"" placeholder=""Cash"" value=""0.0"" class=""form-control"" /></td>
                                <td><input type=""text"" id=""eCardAmt"" name=""eCardAmt"" placeholder=""Card"" value=""0.0"" class=""form-control"" /></td>
                                <td><input type=""text"" id=""e");
                WriteLiteral("CardType\" name=\"eCardType\" placeholder=\"Card Type\"");
                BeginWriteAttribute("value", " value=\"", 6840, "\"", 6848, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" /></td>\r\n                                <td><input type=\"text\" id=\"eCardNo\" name=\"eCardNo\" placeholder=\"Card No\"");
                BeginWriteAttribute("value", " value=\"", 6984, "\"", 6992, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control\" /></td>\r\n                                <td><input type=\"text\" id=\"eAuthCode\" name=\"eAuthCode\" placeholder=\"Auth Code\"");
                BeginWriteAttribute("value", " value=\"", 7134, "\"", 7142, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control"" /></td>

                            </tr>

                        </table>

                    </div>

                </div>
                <div class=""modal-footer"">
                    <button type=""reset"" class=""btn btn-default btn-sm"" data-dismiss=""modal"">Close</button>
                    <button id=""saveEditedBill"" type=""submit"" class=""btn btn-sm btn-danger"">Save</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
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
