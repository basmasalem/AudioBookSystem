#pragma checksum "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "989398f6fbdb78160dff2c4fd27bea274bc02d29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client__ListClient), @"mvc.1.0.view", @"/Views/Client/_ListClient.cshtml")]
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
#line 3 "E:\WebProjects\audioketabsystem\Core.Admin\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\WebProjects\audioketabsystem\Core.Admin\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\WebProjects\audioketabsystem\Core.Admin\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\WebProjects\audioketabsystem\Core.Admin\Views\_ViewImports.cshtml"
using Core.Admin.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\WebProjects\audioketabsystem\Core.Admin\Views\_ViewImports.cshtml"
using Core.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\WebProjects\audioketabsystem\Core.Admin\Views\_ViewImports.cshtml"
using Core.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"989398f6fbdb78160dff2c4fd27bea274bc02d29", @"/Views/Client/_ListClient.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67da798a8ce3be855a3c0be7774be5fa7330848c", @"/Views/_ViewImports.cshtml")]
    public class Views_Client__ListClient : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClientVModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/Views/ClientData.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
  
    int indexer = (int)ViewBag.index;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""table-responsive"">
    <table class=""table table-bordered table-striped"">
        <thead>
            <tr>
                <th>#</th>
                <th>الاسم </th>
                <th>البريد الالكترونى  </th>
                <th> الجوال  </th>
                <th> تاريخ الاضافة  </th>
                <th> </th>


            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 20 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
             foreach (var item in Model.Clients)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n\r\n                    <td>\r\n                        ");
#nullable restore
#line 25 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                   Write(indexer);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 28 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                   Write(item.FullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>");
#nullable restore
#line 30 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                   Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 31 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                   Write(item.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 32 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                   Write(item.RegisterationDate.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                    <td>\r\n                        <div class=\"td-actions\">\r\n                            <a class=\"btn edit-btn\"");
            BeginWriteAttribute("href", " href=\"", 1021, "\"", 1082, 1);
#nullable restore
#line 36 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
WriteAttributeValue("", 1028, Url.Action("Details","Client",new {Id=item.ClientId}), 1028, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"icon-feather\"></i>\r\n                            </a>\r\n                            <a class=\"btn trash-btn\" href=\"#\"");
            BeginWriteAttribute("id", " id=\"", 1243, "\"", 1278, 2);
            WriteAttributeValue("", 1248, "btnClientDelete_", 1248, 16, true);
#nullable restore
#line 39 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
WriteAttributeValue("", 1264, item.ClientId, 1264, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1279, "\"", 1324, 3);
            WriteAttributeValue("", 1289, "ConfirmDeleteClient(", 1289, 20, true);
#nullable restore
#line 39 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
WriteAttributeValue("", 1309, item.ClientId, 1309, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1323, ")", 1323, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-url=\"");
#nullable restore
#line 39 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                                                                                                                                                     Write(Url.Action("DeleteClient"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                <i class=\"icon-trash\"></i>\r\n                            </a>\r\n\r\n                        </div>\r\n                    </td>\r\n\r\n\r\n                </tr>\r\n");
#nullable restore
#line 48 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                indexer++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n        </tbody>\r\n\r\n    </table>\r\n</div>\r\n\r\n\r\n\r\n\r\n");
#nullable restore
#line 62 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
 if (ViewBag.type == 1)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 64 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
Write(Html.PagedListPager(Model.Clients, page => Url.Action("ListClient", new { page }),
    PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions
    {
        ActiveLiElementClass = "page-item active",
        PageClasses = new[] { "page-link" },
        UlElementClasses = new[] { "pagination justify-content-center primary" },
        LiElementClasses = new[] { "page-item" }

    },
    new AjaxOptions() { HttpMethod = "GET", UpdateTargetId = "divListClient" })));

#line default
#line hidden
#nullable disable
#nullable restore
#line 73 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                                                                                
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 77 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
Write(Html.PagedListPager(Model.Clients, page => Url.Action("SearchClient", new { Model.SearchClientVModel.Name, Model.SearchClientVModel.Email, page }),
   PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions
   {
       ActiveLiElementClass = "page-item active",
       PageClasses = new[] { "page-link" },
       UlElementClasses = new[] { "pagination justify-content-center primary" },
       LiElementClasses = new[] { "page-item" }

   },
   new AjaxOptions() { HttpMethod = "POST", UpdateTargetId = "divListClient" })));

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
                                                                                
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "989398f6fbdb78160dff2c4fd27bea274bc02d2911556", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "989398f6fbdb78160dff2c4fd27bea274bc02d2912596", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 90 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_ListClient.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClientVModel> Html { get; private set; }
    }
}
#pragma warning restore 1591