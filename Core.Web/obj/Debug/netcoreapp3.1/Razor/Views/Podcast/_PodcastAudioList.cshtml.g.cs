#pragma checksum "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71c9d53f4038857393d50fa9c22bc083904f7e8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Podcast__PodcastAudioList), @"mvc.1.0.view", @"/Views/Podcast/_PodcastAudioList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71c9d53f4038857393d50fa9c22bc083904f7e8a", @"/Views/Podcast/_PodcastAudioList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d64b5d66b397910bfc8e5d528f27b570cb5ff1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Podcast__PodcastAudioList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<AudioViewModel>>
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
            WriteLiteral("\r\n<div class=\"row\">\r\n\r\n");
#nullable restore
#line 5 "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml"
     if (Model.Count() != 0)
    {
        foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-6 col-md-12 col-12\">\r\n                ");
#nullable restore
#line 10 "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml"
           Write(await Html.PartialAsync("~/Views/Shared/ComponentItem/_AudioItem.cshtml", item));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 12 "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml"
        }
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""col-lg-12 col-md-12 col-12"">
            <div class=""content_div"">

                <div class=""box_sec1"">


                    <div class=""comments"">

                        <div class=""author-comment"">

                            <div class=""no_comment"">
                                <div class=""row"">
                                    <div class=""col-lg-12"">
                                        <div class=""no_commetsec"">
                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "71c9d53f4038857393d50fa9c22bc083904f7e8a6036", async() => {
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
            WriteLiteral("\r\n                                    \r\n                                            <p>");
#nullable restore
#line 32 "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml"
                                          Write(_localizer["noaudio"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>


            </div>
        </div>
");
#nullable restore
#line 46 "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n");
#nullable restore
#line 51 "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml"
         if (ViewBag.Pagination)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"row\">\r\n                <div class=\"col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12\">\r\n                    <div class=\"card\">\r\n                        <div class=\"card-body\">\r\n                            ");
#nullable restore
#line 57 "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml"
                       Write(Html.PagedListPager(Model, page => Url.Action("PodcastAudio", new { Id = ViewBag.podcastId, page }),
            PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions
            {
                ActiveLiElementClass = "page-item active",
                PageClasses = new[] { "page-link" },
                UlElementClasses = new[] { "pagination rounded success justify-content-center" },
                LiElementClasses = new[] { "page-item" }

            },
            new AjaxOptions() { HttpMethod = "GET", UpdateTargetId = "divListPodcastAudio" })));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 71 "E:\WebProjects\audioketabsystem\Core.Web\Views\Podcast\_PodcastAudioList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<AudioViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
