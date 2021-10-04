﻿$(function () {

    $('#btnSaveTag').click(function (evt) {
        debugger;
        $('#btnSaveTag').attr('disabled', 'disabled');
        if ($('#frmAddTag').valid()) {

            if ($("#DescAr").val() == "" || $("#DescEn").val() == "" || $("#hdfAttachments").val() == "0") {
                warningAlert("يجب ادخال كل البيانات");
                $('#btnSaveTag').removeAttr('disabled');
                return false;
            }
            var form = $('#frmAddTag');
            var actionUrl = form.attr('action');
            var sendData = form.serialize() + '&oldImage=' + imageSrcId;;
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    alert("تم الحفظ بنجاح");
                    setTimeout(function () { window.location = "/Tag/Index"; }, 1000);
                }
                else
                    warningAlert("حصل خطأ اثناء الحفظ");

            });
        }
        else
            $('#btnSaveTag').removeAttr('disabled');



    });
});
