#pragma checksum "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d20b0d1a447314f08b70a7d4fd704e39ce0daa7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_Audio), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/Audio.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d20b0d1a447314f08b70a7d4fd704e39ce0daa7c", @"/Views/Shared/EditorTemplates/Audio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67da798a8ce3be855a3c0be7774be5fa7330848c", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_Audio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<style>
    .loader {
        border: 16px solid #f3f3f3; /* Light grey */
        border-top: 16px solid #3498db; /* Blue */
        border-radius: 50%;
        width: 60px;
        height: 60px;
        animation: spin 2s linear infinite;
    }

    ");
            WriteLiteral("@keyframes spin {\r\n        0% {\r\n            transform: rotate(0deg);\r\n        }\r\n\r\n        100% {\r\n            transform: rotate(360deg);\r\n        }\r\n    }\r\n</style>\r\n");
            WriteLiteral("\r\n\r\n\r\n");
#nullable restore
#line 28 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
Write(Html.Hidden("", null, new { @id = "hdfAudioAttachments" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-xl-6 col-lg-6 col-md-6 col-sm-6 col-6\">\r\n    <div class=\"input-group\">\r\n        <div class=\"custom-file\">\r\n");
#nullable restore
#line 32 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
             using (Html.BeginForm("", "", FormMethod.Post,
    new { @id = "frmAddAudioAttach", @enctype = "multipart/form-data" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <input type=\"file\" class=\"custom-file-input\" name=\"file\" onchange=\"uploadAudioAttach()\" id=\"uploadAudio\" />\r\n                <label class=\"custom-file-label\" for=\"uploadAudio\">أختر الملف...</label>\r\n");
#nullable restore
#line 37 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<div class=\"col-xl-12 col-lglg-12 col-md-12 col-sm-12 col-12\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 1181, "\"", 1189, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"card-body\" id=\"divAudioAttachments\">\r\n\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>\r\n<div class=\"loader\" id=\"loaderAudio\" style=\"display:none;\"></div>\r\n\r\n\r\n\r\n\r\n<script>\r\n\r\n");
            WriteLiteral("    $(function () {\r\n        $(\'#hdfAudioAttachments\').val(\'");
#nullable restore
#line 61 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
                                  Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n        debugger;\r\n        if (\'");
#nullable restore
#line 63 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
        Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\' != \"0\") {\r\n            var tr = `<div class=\"avatar xxxl\" id=\"div_");
#nullable restore
#line 64 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
                                                  Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <a href=\"/Attachments/Audios/");
#nullable restore
#line 65 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
                                        Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" download target=\"_blank\" style=\"color: #747474\"> <img src=\"/images/audio.png\" class=\"circle img-avatar\" alt=\"AudioKetab\"></a>\r\n                <button type=\"button\" class=\"close btn-close\" aria-label=\"Close\" onclick=\"removeItemAudio(\'");
#nullable restore
#line 66 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
                                                                                                      Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"')"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>`;
            $('#divAudioAttachments').html("""").append(tr);
        }
    });

    function uploadAudioAttach() {
        debugger;
        var formdata = new FormData();
        var fileInput = document.getElementById('uploadAudio');
        if (fileInput.files.length > 0) {
            $(""#loaderAudio"").show();
            var attachAudioId = $('#hdfAudioAttachments').val();
            if (attachAudioId != ""0"") {
                removeItemAudio(attachAudioId);
            }
            for (i = 0; i < fileInput.files.length; i++) {
                if (!(fileInput.files[i].name.endsWith("".mp3"") || fileInput.files[i].name.endsWith("".wav"") || fileInput.files[i].name.endsWith("".WAV""))) {
                    $(""#loader"").hide();
                    warningAlert("" يجب رفع ملف من نوع mp3 او wav او WAV "");
                    $(""#uploadAudio"").val("""");
                    return fal");
            WriteLiteral("se;\r\n                }\r\n                formdata.append(fileInput.files[i].name, fileInput.files[i]);\r\n            }\r\n\r\n\r\n            var desc = \"qqq\";\r\n            var xhr = new XMLHttpRequest();\r\n            xhr.open(\'POST\', \'");
#nullable restore
#line 97 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
                         Write(Url.Action("UploadFile", "Base"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
            xhr.send(formdata);

            xhr.onreadystatechange = function (ress) {

                if (xhr.readyState == 4 && xhr.status == 200) {
                    var res = JSON.parse(ress.currentTarget.responseText);
                    debugger;
                    var tr = `<div class=""avatar xxxl"" id=""div_` + res.src + `"">
                            <a href=""` + res.path + `"" download target=""_blank"" style=""color: #747474""> <img src=""/images/audio.png"" class=""circle img-avatar"" alt=""AudioKetab""></a>
                            <button type=""button"" class=""close btn-close"" aria-label=""Close"" onclick=""removeItemAudio('`+ res.src +`')"" >
                                <span aria-hidden=""true"">&times;</span>
                            </button>
                        </div>`;
                    $('#divAudioAttachments').html("""").append(tr);
                
                    $('#hdfAudioAttachments').val(res.src);
                    $(""#loaderAudio"").hide();

         ");
            WriteLiteral(@"       }
            }
        } else {
            console.log(""no files"");
        }

    }


    function removeItemAudio(id) {     
        var divAudio = document.getElementById('div_' + id);
        if (divAudio != null)
            divAudio.remove();

        if ($('#hdfAudioAttachments').val() != ""0"") {
            $('#hdfAudioAttachments').val(""0"");
        }


        //if ((audioSrcId != id)) {
            $.post(""");
#nullable restore
#line 136 "E:\WebProjects\audioketabsystem\Core.Admin\Views\Shared\EditorTemplates\Audio.cshtml"
               Write(Url.Action( "RemoveUpload", "Base"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""", { ""id"": id, ""type"": 3 }, function (res) {
                if (res == ""-1"") {
                    console.log(""حصل خطأ"");
                }
                else if (res == ""-2"")
                    console.log(""ملف الصوت مش موجوده"");
                else if (res == ""1"") {
                    console.log(""تم حذف ملف الصوت"");
                    $(""#uploadAudio"").val("""");
                }

            });
        //}
    }

</script>


");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591