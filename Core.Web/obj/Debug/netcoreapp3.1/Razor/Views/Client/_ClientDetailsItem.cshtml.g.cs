#pragma checksum "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13e899619371c2d613c7b9fe704159e55ce4f5d4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client__ClientDetailsItem), @"mvc.1.0.view", @"/Views/Client/_ClientDetailsItem.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13e899619371c2d613c7b9fe704159e55ce4f5d4", @"/Views/Client/_ClientDetailsItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d64b5d66b397910bfc8e5d528f27b570cb5ff1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Client__ClientDetailsItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ReaderVM>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ClientProfile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Client", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
  
    string adminUrl = configuration.GetValue<string>("AdminUrl");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"decorations\">\r\n    <div class=\"card decoration\">\r\n        <div class=\"card-header\">\r\n            <div class=\"card-title\">\r\n                <img");
            BeginWriteAttribute("src", " src=", 263, "", 358, 1);
#nullable restore
#line 11 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
WriteAttributeValue("", 268, ViewBag.Item=="followers"?"/assets/img/icon/listner.png":"/assets/img/icon/speaker.png", 268, 90, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 11 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
                                                                                                                Write(_localizer[ViewBag.Item]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <span>");
#nullable restore
#line 13 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
                 Write(ViewBag.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"card-body\">\r\n            <div class=\"images_decoration_listner\">\r\n");
#nullable restore
#line 19 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
                 if (Model.Count() != 0)
                {
                    foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"box\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13e899619371c2d613c7b9fe704159e55ce4f5d46464", async() => {
                WriteLiteral("<img");
                BeginWriteAttribute("src", " src=\"", 846, "\"", 956, 1);
#nullable restore
#line 24 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
WriteAttributeValue("", 852, string.IsNullOrEmpty(item.Image)?"/assets/img/d-user.png": adminUrl+"/Attachments/Images/"+item.Image, 852, 104, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 957, "\"", 963, 0);
                EndWriteAttribute();
                WriteLiteral(">");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-key", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 24 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
                                                                                     WriteLiteral(item.Key);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["key"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-key", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["key"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </div>\r\n");
#nullable restore
#line 26 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 29 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
                 if (ViewBag.showAllOrNot)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"box\">\r\n                        <a class=\"total_listner\" href=\"javascript:void(0)\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1223, "\"", 1274, 5);
            WriteAttributeValue("", 1233, "ShowModal(\'", 1233, 11, true);
#nullable restore
#line 32 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
WriteAttributeValue("", 1244, ViewBag.Item, 1244, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1257, "\',\'", 1257, 3, true);
#nullable restore
#line 32 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
WriteAttributeValue("", 1260, ViewBag.key, 1260, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1272, "\')", 1272, 2, true);
            EndWriteAttribute();
            WriteLiteral("><span>");
#nullable restore
#line 32 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
                                                                                                                                Write(_localizer["all"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></a>\r\n                    </div>\r\n");
#nullable restore
#line 34 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientDetailsItem.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ReaderVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
