#pragma checksum "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "155e6ab07627435d4dc40386d57b58c08a6fcca7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Category__CategoryList), @"mvc.1.0.view", @"/Views/Category/_CategoryList.cshtml")]
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
#line 3 "E:\WebProjects\audioketabsystem\Core.Web\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\WebProjects\audioketabsystem\Core.Web\Views\_ViewImports.cshtml"
using Core.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\WebProjects\audioketabsystem\Core.Web\Views\_ViewImports.cshtml"
using Core.Web.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\WebProjects\audioketabsystem\Core.Web\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\WebProjects\audioketabsystem\Core.Web\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\WebProjects\audioketabsystem\Core.Web\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"155e6ab07627435d4dc40386d57b58c08a6fcca7", @"/Views/Category/_CategoryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d64b5d66b397910bfc8e5d528f27b570cb5ff1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Category__CategoryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<CategoryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Sound", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
   
    string adminUrl = configuration.GetValue<string>("AdminUrl");


#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"row\">\r\n\r\n\r\n");
#nullable restore
#line 11 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
     if (Model.Count != 0)
    {
        foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"Services-wrap\">\r\n                <div class=\"Services-item\">\r\n                    <div class=\"Services-icon\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 388, "\"", 497, 1);
#nullable restore
#line 18 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
WriteAttributeValue("", 394, string.IsNullOrEmpty(item.Image)?"/assets/img/default.png":adminUrl+"Attachments/Images/"+item.Image, 394, 103, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 498, "\"", 504, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </div>\r\n                    <div class=\"Services-desc\">\r\n\r\n                        <h4 class=\"services-title\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "155e6ab07627435d4dc40386d57b58c08a6fcca75935", async() => {
#nullable restore
#line 23 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
                                                                                                 Write(ViewBag.langId==1? item.NameAr:item.NameEn);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 23 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
                                                                              WriteLiteral(item.Key);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </h4>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 28 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
        }
    }
    else
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
   Write(await Html.PartialAsync("~/Views/Home/_NoData.cshtml", "nocategory"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
                                                                             

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12\">\r\n        <div class=\"card\">\r\n            <div class=\"card-body\">\r\n");
#nullable restore
#line 43 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
                 if (ViewBag.Pagination)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
               Write(Html.PagedListPager(Model, page => Url.Action("CategoryList", new { page }),
                                  PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions
                                  {
                                      ActiveLiElementClass = "page-item active",
                                      PageClasses = new[] { "page-link" },
                                      UlElementClasses = new[] { "pagination justify-content-center primary" },
                                      LiElementClasses = new[] { "page-item" }

                                  },
                                  new AjaxOptions() { HttpMethod = "GET", UpdateTargetId = "divListCategory" })));

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "E:\WebProjects\audioketabsystem\Core.Web\Views\Category\_CategoryList.cshtml"
                                                                                                                

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n        </div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public Microsoft.AspNetCore.Mvc.Localization.IViewLocalizer _localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IConfiguration configuration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<CategoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
