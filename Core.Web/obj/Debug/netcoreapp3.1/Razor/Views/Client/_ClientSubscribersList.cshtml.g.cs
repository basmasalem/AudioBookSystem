#pragma checksum "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45c652df383c1e94fe0b88961c818e7ccfef86bb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client__ClientSubscribersList), @"mvc.1.0.view", @"/Views/Client/_ClientSubscribersList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"45c652df383c1e94fe0b88961c818e7ccfef86bb", @"/Views/Client/_ClientSubscribersList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d64b5d66b397910bfc8e5d528f27b570cb5ff1f", @"/Views/_ViewImports.cshtml")]
    public class Views_Client__ClientSubscribersList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedList<ReaderVM>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
 if (Model.Count() != 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n\r\n\r\n");
#nullable restore
#line 9 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-3 col-md-4 col-sm-12\">\r\n                ");
#nullable restore
#line 12 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
           Write(await Html.PartialAsync("~/Views/Shared/ComponentItem/_ClientItem.cshtml", item));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n");
#nullable restore
#line 14 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 17 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
Write(await Html.PartialAsync("~/Views/Home/_NoData.cshtml", "nosubscriber"));

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
                                                                           

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 24 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
 if (ViewBag.Pagination)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row\">\r\n        <div class=\"col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12\">\r\n            <div class=\"card\">\r\n                <div class=\"card-body\">\r\n                    ");
#nullable restore
#line 30 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
               Write(Html.PagedListPager(Model, page => Url.Action("ClientSubscribersList", new { page }),
                          PagedListRenderOptions.EnableUnobtrusiveAjaxReplacing(new PagedListRenderOptions
                          {
                              ActiveLiElementClass = "page-item active",
                              PageClasses = new[] { "page-link" },
                              UlElementClasses = new[] { "pagination rounded success justify-content-center" },
                              LiElementClasses = new[] { "page-item" }

                          },
                          new AjaxOptions() { HttpMethod = "GET", UpdateTargetId = "divSubscribersList" })));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 44 "E:\WebProjects\audioketabsystem\Core.Web\Views\Client\_ClientSubscribersList.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedList<ReaderVM>> Html { get; private set; }
    }
}
#pragma warning restore 1591
