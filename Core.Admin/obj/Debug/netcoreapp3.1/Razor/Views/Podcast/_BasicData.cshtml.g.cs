#pragma checksum "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "833112a81fd58f94d77c834323137119ab063365"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Podcast__BasicData), @"mvc.1.0.view", @"/Views/Podcast/_BasicData.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"833112a81fd58f94d77c834323137119ab063365", @"/Views/Podcast/_BasicData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67da798a8ce3be855a3c0be7774be5fa7330848c", @"/Views/_ViewImports.cshtml")]
    public class Views_Podcast__BasicData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PodcastViewModel>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <div class=\"row gutters\">\r\n        <div class=\"col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12\">\r\n            <div class=\"ticket-status-card height-div\">\r\n                <h6><i class=\"icon-user1\"></i> ??????????</h6>\r\n                <h3>");
#nullable restore
#line 7 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
               Write(Model.NameAr);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                <h3>");
#nullable restore
#line 8 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
               Write(Model.NameEn);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
            </div>
        </div>
        <div class=""col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12"">
            <div class=""ticket-status-card height-div"">
                <h6><i class=""icon-schedule""></i> ?????????? ??????????????</h6>
                <h3>");
#nullable restore
#line 14 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
               Write(Model.StartDate.Value.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n\r\n            </div>\r\n        </div>\r\n        <div class=\"col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12\">\r\n            <div class=\"ticket-status-card height-div\">\r\n                <h6><i class=\"icon-layers\"></i> ??????????</h6>\r\n                <h3>");
#nullable restore
#line 21 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
                Write(Model.Type==PodcastType.Public?"??????":"??????");

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n            </div>\r\n        </div>\r\n        <div class=\"col-xl-3 col-lg-3 col-md-6 col-sm-6 col-12\">\r\n            <div class=\"ticket-status-card height-div\">\r\n                <h6><i class=\"icon-download\"></i> ?????????? ??????</h6>\r\n");
#nullable restore
#line 27 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
                 if (!string.IsNullOrEmpty(Model.Attachment))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "833112a81fd58f94d77c834323137119ab0633656113", async() => {
                WriteLiteral("<img class=\"download_pdf\"");
                BeginWriteAttribute("src", " src=\"", 1320, "\"", 1403, 1);
#nullable restore
#line 29 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
WriteAttributeValue("", 1326, Model.Attachment.Contains("pdf")?"/images/download.png":"/images/word.png", 1326, 77, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("download", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1256, "~/Attachments/Files/", 1256, 20, true);
#nullable restore
#line 29 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
AddHtmlAttributeValue("", 1276, Model.Attachment, 1276, 17, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 30 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n        </div>\r\n");
            WriteLiteral("\r\n        <div class=\"col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12\">\r\n            <div class=\"ticket-status-card customScroll9\">\r\n                <h6><i class=\"icon-border_color\"></i> ????????????????</h6>\r\n                <p class=\"txt-right\">");
#nullable restore
#line 45 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
                                Write(Html.Raw(Model.DescAr));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
            </div>
        </div>
        <div class=""col-xl-6 col-lg-6 col-md-6 col-sm-12 col-12"">
            <div class=""ticket-status-card customScroll9"">
                <h6><i class=""icon-border_color""></i> ????????????????</h6>
                <p class=""txt-left"">");
#nullable restore
#line 51 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Podcast\_BasicData.cshtml"
                               Write(Html.Raw(Model.DescEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PodcastViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
