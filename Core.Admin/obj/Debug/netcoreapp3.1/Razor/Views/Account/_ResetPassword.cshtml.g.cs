#pragma checksum "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00b167a3786ad1c9e1949e3634e33b46f4b402b3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account__ResetPassword), @"mvc.1.0.view", @"/Views/Account/_ResetPassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00b167a3786ad1c9e1949e3634e33b46f4b402b3", @"/Views/Account/_ResetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67da798a8ce3be855a3c0be7774be5fa7330848c", @"/Views/_ViewImports.cshtml")]
    public class Views_Account__ResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResetPasswordView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"
 using (Html.BeginForm("", "", FormMethod.Post, new { @id = "frmChangePassword",@action= "ResetPassword" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"
Write(Html.HiddenFor(x => x.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <label class=\"label-name\">البريد الالكتروني</label>\r\n        <div class=\"input-group\">\r\n            ");
#nullable restore
#line 12 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"
       Write(Html.TextBoxFor(c => c.Email, new { @class = "form-control", @readonly = "readonly" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <div class=\"form-group\">\r\n        <label class=\"label-name\">كلمة المرور</label>\r\n        <div class=\"input-group\">\r\n            ");
#nullable restore
#line 19 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"
       Write(Html.TextBoxFor(c => c.Password, new { @class = "form-control", @type = "password" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 20 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"
       Write(Html.ValidationMessageFor(x => x.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <label class=\"label-name\">تاكيد كلمة المرور</label>\r\n        <div class=\"input-group\">\r\n            ");
#nullable restore
#line 26 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"
       Write(Html.TextBoxFor(c => c.ConfirmPassword, new { @class = "form-control", @type = "password" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 27 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"
       Write(Html.ValidationMessageFor(x => x.ConfirmPassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
            WriteLiteral("    <div align=\"center\" class=\"card-footer\" style=\"padding: 10px;\">\r\n        <a href=\"#\" class=\"btn btn-save\" onclick=\"SavePassword()\"><i class=\"fa fa-save\"></i> حفظ </a>\r\n    </div>\r\n");
#nullable restore
#line 35 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Account\_ResetPassword.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResetPasswordView> Html { get; private set; }
    }
}
#pragma warning restore 1591