$(function () {



    $('#btnSaveAudio').click(function (evt) {
        debugger;
        $('#btnSaveAudio').attr('disabled', 'disabled');
        if ($('#frmAudio').valid()) {

            if ($("#DescAr").val() == "" || $("#DescEn").val() == "" || $("#hdfAttachments").val() == "0" || $("#hdfFileAttachments").val() == "0" || $("#hdfAudioAttachments").val() == "0") {
                warningAlert("يجب ادخال كل البيانات");
                $('#btnSaveAudio').removeAttr('disabled');
                return false;
            }
            var form = $('#frmAudio');
            var actionUrl = form.attr('action');
            var sendData = form.serialize()  ;
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    alert("تم الحفظ بنجاح");
                    setTimeout(function () { window.location = "/Audio/Index"; }, 2000);
                }
                else if (res == -2)
                    warningAlert("تاريخ البدايه لازم اكبر من تاريخ اليوم");
                else if (res == -3)
                    warningAlert("تاريخ النهايه لازم اكبر من تاريخ البداية");
                else
                    warningAlert("حصل خطأ اثناء الحفظ");
                $('#btnSaveAudio').removeAttr('disabled');

            });
        }
        else
            $('#btnSaveAudio').removeAttr('disabled');
    });

    $('#audioButton').click(function (evt) {
        var RecordId = $('#hdfRecordAttachments').val();
        if (RecordId != "0") {

            swal({
                title: "تأكيد",
                text: " سيتم حذف ملف الصوت المسجل بمجرد اختيار رفع ملف صوت!",
                icon: "warning",
                buttons: ["لا", "نعم"],
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        removeRecord(RecordId);
                        $.get("/Audio/GetAudio").done(function (res) {
                            $("#recordaudioDiv").html(" ").append(res);
                        });
                    } else {
                        debugger;
                        this.checked = false;
                        $('#record_Button').prop({ 'aria-checked': 'true', 'checked': true });
                    /*    $('#record_Button').attr("checked", true);*/
                    }
                });
      
        } else {
        
            $.get("/Audio/GetAudio").done(function (res) {
                $("#recordaudioDiv").html(" ").append(res);
            });
        
        }
    });

    $('#record_Button').click(function (evt) {
        var AudioId = $('#hdfAudioAttachments').val();
        if (AudioId != "0") {
            swal({
                title: "تأكيد",
                text: " سيتم حذف ملف الصوت المرفوع بمجرد اختيار تسجيل ملف صوت!",
                icon: "warning",
                buttons: ["لا", "نعم"],
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        removeItemAudio(AudioId);
                        $.get("/Audio/GetRecord").done(function (res) {
                            $("#recordaudioDiv").html(" ").append(res);
                        });
                    } else {
                        debugger;

                        this.checked = false;
                        //$('#audioButton').attr("checked", true);
                        $('#audioButton').prop({ 'aria-checked': 'true', 'checked': true });
                    }
                });

        } else {

            $.get("/Audio/GetRecord").done(function (res) {
                $("#recordaudioDiv").html(" ").append(res);
            });

        }
  
    });
});


function DeleteUploadAudio(AudioId) {
    $("#recordDiv").show();
    $("#audioDiv").hide();
    removeItemAudio(AudioId);
}

window.onload = function () {
    
    var UploadType = $("#UploadTypeName").val();
    if (UploadType == "Upload") {
        $("#recordDiv").hide();
        $("#audioDiv").show();
    } else if (UploadType == "Record") {
        $("#recordDiv").show();
        $("#audioDiv").hide();

        document.getElementById("recordButton").disabled = true;
    }



};

function ChangeAudioRateApprove(id, flag) {
    $.get("/Audio/ChangeAudioRateApprove", { id: id, flag: flag }).done(function (res) {
        if (res.code == "1") {
            alert("تم تغير التقييم بنجاح");
            $.get("/Audio/ListAudioRate", { page: 1, audioId: res.id }).done(function (data) {
                $("#divListAudioRate").html(data);
            });
        }
    });
}