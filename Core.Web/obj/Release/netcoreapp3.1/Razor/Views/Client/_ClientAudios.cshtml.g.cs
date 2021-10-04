#pragma checksum "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f45e190bba04fada8194417047cbf4ae76110c31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client__ClientAudios), @"mvc.1.0.view", @"/Views/Client/_ClientAudios.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f45e190bba04fada8194417047cbf4ae76110c31", @"/Views/Client/_ClientAudios.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d64b5d66b397910bfc8e5d528f27b570cb5ff1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Client__ClientAudios : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList<AudioViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("no-voice"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/icon/no-voice.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
  
    string adminUrl = configuration.GetValue<string>("AdminUrl");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
 if (Model.Count != 0)
{
    foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"content_div\">\r\n\r\n            <div class=\"box_sec1\">\r\n                <div class=\"img_box\">\r\n                    <img");
            BeginWriteAttribute("src", " src=\"", 317, "\"", 450, 1);
#nullable restore
#line 16 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
WriteAttributeValue("", 323, string.IsNullOrEmpty(item.PublisherImage) ? "/assets/img/d-user.png" : adminUrl+"/Attachments/Images/" + item.PublisherImage, 323, 127, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n                <div class=\"data_box\">\r\n                    <h3>");
#nullable restore
#line 19 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
                    Write(ViewBag.langId == 1 ? item.PublisherNameAr : item.PublisherNameEn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n                    <span>");
#nullable restore
#line 20 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
                     Write(item.CreationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                </div>\r\n                <p class=\"p_consulter\">\r\n\r\n                    ");
#nullable restore
#line 24 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
               Write(Html.Raw(ViewBag.langId == 1 ? item.DescriptionAr : item.DescriptionEn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n\r\n                ");
#nullable restore
#line 27 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
           Write(await Html.PartialAsync("~/Views/Shared/ComponentItem/_AudioItem.cshtml", item));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"comments\"");
            BeginWriteAttribute("id", " id=\"", 993, "\"", 1027, 2);
            WriteAttributeValue("", 998, "audiocommentdiv_", 998, 16, true);
#nullable restore
#line 29 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
WriteAttributeValue("", 1014, item.AudioId, 1014, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 30 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
                       ViewBag.audio = item.AudioId;

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
#nullable restore
#line 31 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
               Write(await Html.PartialAsync("~/Views/Shared/ComponentItem/_AudioCommentsItem.cshtml", item.AudioComments));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n\r\n\r\n        </div>\r\n");
#nullable restore
#line 37 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
    }
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""content_div"">

        <div class=""box_sec1"">


            <div class=""comments"">

                <div class=""author-comment"">

                    <div class=""no_comment"">
                        <div class=""row"">
                            <div class=""col-lg-12"">
                                <div class=""no_commetsec"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "f45e190bba04fada8194417047cbf4ae76110c318817", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <p>");
#nullable restore
#line 55 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
                                  Write(_localizer["noaudio"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n\r\n    </div>\r\n");
#nullable restore
#line 68 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 71 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
 if (ViewBag.Pagination)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12\">\r\n            <div class=\"card\">\r\n                <div class=\"card-body\">\r\n                    ");
#nullable restore
#line 77 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
               Write(Html.PagedListPager(Model, page => Url.Action("ClientAudios", new { ViewBag.key, page }),
                          PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions
                          {
                              ActiveLiElementClass = "page-item active",
                              PageClasses = new[] { "page-link" },
                              UlElementClasses = new[] { "pagination rounded success justify-content-center" },
                              LiElementClasses = new[] { "page-item" }

                          },
                          new AjaxOptions() { HttpMethod = "GET", UpdateTargetId = "divAudioList" })));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 91 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientAudios.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList<AudioViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
