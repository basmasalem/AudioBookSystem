



function uploadImage() {

    debugger;
    var formdata = new FormData();
    var fileInput = document.getElementById('filImage');
    if (fileInput.files.length > 0) {
        $("#loaderImg").show();
        for (i = 0; i < fileInput.files.length; i++) {
            debugger;
            if (!(fileInput.files[i].name.endsWith(".jpg") || fileInput.files[i].name.endsWith(".jpeg") || fileInput.files[i].name.endsWith(".png"))) {
                $("#loaderImg").hide();
                warningAlert(message.ImgMsg);
                $("#filImage").val("");
                return false;
            }
            if (fileInput.files[i].size > 6000000) {
                $("#loaderImg").hide();
                $("#filImage").val("");
                warningAlert(message.ImgSizeMsg);
                return false;
            }
            var attachId = $('#hdfAttachments').val();
            if (attachId != "0") {
                removeImage(attachId);
            }
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }


        var desc = "qqq";
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Base/UploadFile');
        xhr.send(formdata);
        xhr.onreadystatechange = function (ress) {

            if (xhr.readyState == 4 && xhr.status == 200) {
                var res = JSON.parse(ress.currentTarget.responseText);
                var tr = `  <div class="image_upload">
                                    <img src="` + res.path + `" >
                                </div>
                                <div class="user_delete"><a href="javascript:void(0)"  onclick="removeImage('`+ res.src + `')" ><img src="/assets/img/icon/delete.png" ></a></div>`;
                debugger;
                $("#divImgUpload").removeClass("col-lg-12");
                $("#divImgUpload").addClass("after_upload col-lg-6");
                $('#imageres').html("").append(tr);

                //$('#audioImagediv').css("display", "none");
                //$('#divAttachments').css("display", "block");
                $('#hdfAttachments').val(res.src);
                $("#loaderImg").hide();

            }
        }
    } else {
        console.log("no files");
    }

}



function removeImage(id) {
    debugger;
    //$('#audioImagediv').css("display", "block");
    //$('#divAttachments').css("display", "none");

    var div = document.getElementById('imageres');
    if (div != null) {
        $('#imageres').empty();
        $("#divImgUpload").removeClass("after_upload col-lg-6");
        $("#divImgUpload").addClass("col-lg-12");
    }


    if ($('#hdfAttachments').val() != "0") {
        $('#hdfAttachments').val("0");

    }

    $.post("/Base/RemoveUpload", { "id": id, "type": 1 }, function (res) {
        if (res == "-1") {
            console.log("حصل خطأ");
        }
        else if (res == "-2")
            console.log("الصورة مش موجوده");
        else if (res == "1") {
            console.log("تم حذف الصورة");
            $("#filImage").val("");
        }

    });

}

function removeRecord(id) {

    var liRecord = document.getElementById('liRecord');
    if (liRecord != null)
        liRecord.remove();

    $("#deleteRecordanchor").remove();
    $("#divRecord").css("display", "none");
    $("#audioRecordDiv").css("display", "block");
    $("#audioSrcdiv").removeClass("disabledbutton");


    if ($('#hdfRecordAttachments').val() != "0") {
        $('#hdfRecordAttachments').val("0");
    }
    $.post("/Base/RemoveUpload", { "id": id, "type": 3 }, function (res) {
        if (res == "-1") {
            console.log("حصل خطأ");
        }
        else if (res == "-2")
            console.log("ملف الصوت مش موجوده");
        else if (res == "1") {
            console.log("تم حذف ملف الصوت");
            repeatRecording();

        }

    });

}



function uploadAudioAttach() {
  
    var formdata = new FormData();
    var fileInput = document.getElementById('fileAudio');
    if (fileInput.files.length > 0) {
        $("#loaderAudio").show();
        $("#audioSrcdiv").addClass("disabledbutton");
        for (i = 0; i < fileInput.files.length; i++) {
            if (!(fileInput.files[i].name.endsWith(".mp3") || fileInput.files[i].name.endsWith(".wav") || fileInput.files[i].name.endsWith(".WAV"))) {
                $("#loaderAudio").hide();
                warningAlert(" يجب رفع ملف من نوع mp3 او wav او WAV ");
                $("#uploadAudio").val("");
                $("#loaderAudio").hide();
                $("#audioSrcdiv").removeClass("disabledbutton");
                return false;
            }
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }


        var desc = "qqq";
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Base/UploadFile');
        xhr.send(formdata);

        xhr.onreadystatechange = function (ress) {

            if (xhr.readyState == 4 && xhr.status == 200) {
                var res = JSON.parse(ress.currentTarget.responseText);
                debugger;
                var bn = document.getElementById("deleteaudiobtn");
                var au = document.createElement('audio');
                au.controls = true;
                au.src = res.path;
                //bn.onclick = function (event) {
                //    removeItemAudio(res.src);
                //}
    bn.setAttribute("onclick", "removeItemAudio('" + res.src + "');");

                $('#audiosrc').html("").append(au);
                $('#audioSrcdiv').css("display", "none");
                $('#uploadAudiosrc').css("display", "block");
                $('#hdfRecordAttachments').val(res.src);
                $('#UploadType').val("1");
                $("#loaderAudio").hide();
            }
        }
    } else {
        console.log("no files");
    }

}


function removeItemAudio(id) {
    debugger;
    $("#audioSrcdiv").removeClass("disabledbutton");

    $('#audioSrcdiv').css("display", "block");
    $('#uploadAudiosrc').css("display", "none");

    if ($('#hdfRecordAttachments').val() != "0") {
        $('#hdfRecordAttachments').val("0");
    }

    $.post("/Base/RemoveUpload", { "id": id, "type": 3 }, function (res) {
        if (res == "-1") {
            console.log("حصل خطأ");
        }
        else if (res == "-2")
            console.log("ملف الصوت مش موجوده");
        else if (res == "1") {
            console.log("تم حذف ملف الصوت");
            $("#uploadAudio").val("");
        }

    });

}

function uploadFileAttach() {
    debugger;
    var formdata = new FormData();
    var fileInput = document.getElementById('uploadFile');
    if (fileInput.files.length > 0) {
        $("#loaderFile").show();
        for (i = 0; i < fileInput.files.length; i++) {
            if (!(fileInput.files[i].name.endsWith(".pdf") || fileInput.files[i].name.endsWith(".doc") || fileInput.files[i].name.endsWith(".docx"))) {
                $("#loaderFile").hide();
                warningAlert(message.FileMsg);
                $("#uploadFile").val("");
                return false;
            }
            var attachFileId = $('#hdfFileAttachments').val();
            if (attachFileId != "0") {
                removeItemFile(attachFileId);
            }
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }


        var desc = "qqq";
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Base/UploadFile');
        xhr.send(formdata);

        xhr.onreadystatechange = function (ress) {

            if (xhr.readyState == 4 && xhr.status == 200) {
                var res = JSON.parse(ress.currentTarget.responseText);
                debugger;
                var file = res.src;
                var image = file.includes("pdf") ? "/assets/Images/pdf.png" : "/assets/Images/word.png";
                var tr = `<div class="image_upload" id="div_` + res.src + `">
                            <a href="` + res.path + `" download target="_blank" style="color: #747474"> <img src="` + image + `" class="circle img-avatar" alt="AudioKetab"></a>
                            </div>
                            <div class="user_delete"><a href="javascript:void(0)"  onclick="removeItemFile('`+ res.src + `')" ><img src="/assets/img/icon/delete.png" ></a></div>`;
                if (document.getElementById("divFileUpload") != null) {
                    $("#divFileUpload").removeClass("col-lg-12");
                    $("#divFileUpload").addClass("after_upload col-lg-6");
                }
                $('#files').html("").append(tr);
                $('#hdfFileAttachments').val(res.src);
                $("#loaderFile").hide();

            }
        }
    } else {
        console.log("no files");
    }

}

function removeItemFile(id) {


    var divFile = document.getElementById('div_' + id);
    if (divFile != null) {
        $('#files').empty();
        if (document.getElementById("divFileUpload") != null) {
            $("#divFileUpload").removeClass("after_upload col-lg-6");
            $("#divFileUpload").addClass("col-lg-12");
        }
     
    }

    if ($('#hdfFileAttachments').val() != "0") {
        $('#hdfFileAttachments').val("0");
    }

    $.post("/Base/RemoveUpload", { "id": id, "type": 2 }, function (res) {
        if (res == "-1") {
            console.log("حصل خطأ");
        }
        else if (res == "-2")
            console.log("الملف مش موجوده");
        else if (res == "1") {
            console.log("تم حذف الملف");
            $("#uploadFile").val("");
        }

    });

}
