#pragma checksum "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_GetBasicData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24d7d1af2215982ffc62fa5da5b004977c771399"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Client__GetBasicData), @"mvc.1.0.view", @"/Views/Client/_GetBasicData.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24d7d1af2215982ffc62fa5da5b004977c771399", @"/Views/Client/_GetBasicData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67da798a8ce3be855a3c0be7774be5fa7330848c", @"/Views/_ViewImports.cshtml")]
    public class Views_Client__GetBasicData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ClientDataVM>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    <div class=""card-body"" style=""background: #f5f6fa;"">

        <!-- Row starts -->
        <div class=""row gutters"">
            <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-4"">
                <div class=""invoice-status"">
                    <i class=""icon-user""></i>
                    <h2 class=""status text-success"">?????????? ??????????</h2>
                    <h5 class=""status-title"">");
#nullable restore
#line 10 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_GetBasicData.cshtml"
                                        Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h5>

                </div>
            </div>
            <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-4"">
                <div class=""invoice-status"">
                    <i class=""icon-user""></i>
                    <h2 class=""status text-success"">?????????? ????????????</h2>
                    <h5 class=""status-title"">");
#nullable restore
#line 18 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_GetBasicData.cshtml"
                                        Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>

                </div>
            </div>
            <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-4"">
                <div class=""invoice-status"">
                    <i class=""icon-email""></i>
                    <h2 class=""status text-success"">???????????? ????????????????????</h2>
                    <h5 class=""status-title"">");
#nullable restore
#line 26 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_GetBasicData.cshtml"
                                        Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>

                </div>
            </div>
            <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-4"">
                <div class=""invoice-status"">
                    <i class=""icon-lock""></i>
                    <h2 class=""status text-success"">???????? ????????????</h2>
                    <h5 class=""status-title"">");
#nullable restore
#line 34 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_GetBasicData.cshtml"
                                        Write(Model.Password);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n                </div>\r\n            </div>\r\n\r\n");
            WriteLiteral(@"            <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-4"">
                <div class=""invoice-status"">
                    <i class=""icon-map""></i>
                    <h2 class=""status text-success"">?????? ??????????????</h2>
                    <h5 class=""status-title"">");
#nullable restore
#line 51 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_GetBasicData.cshtml"
                                        Write(Model.City);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h5>

                </div>
            </div>
            <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-4"">
                <div class=""invoice-status"">
                    <i class=""icon-phone""></i>
                    <h2 class=""status text-success"">?????? ????????????</h2>
                    <h5 class=""status-title"">");
#nullable restore
#line 59 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_GetBasicData.cshtml"
                                        Write(Model.Phone);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n                </div>\r\n            </div>\r\n\r\n");
            WriteLiteral(@"
            <div class=""col-xl-3 col-lg-3 col-md-3 col-sm-4"">
                <div class=""invoice-status"">
                    <i class=""icon-watch_later""></i>
                    <h2 class=""status text-success"">?????????? ??????????????</h2>
                    <h5 class=""status-title"">");
#nullable restore
#line 77 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Client\_GetBasicData.cshtml"
                                        Write(Model.RegisterationDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n\r\n                </div>\r\n            </div>\r\n");
            WriteLiteral("\r\n        </div>\r\n        <!-- Row ends -->\r\n\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ClientDataVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
