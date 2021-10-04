$(function () {

    $('#btnSaveCategory').click(function (evt) {
        debugger;
        $('#btnSaveCategory').attr('disabled', 'disabled');
        if ($('#frmCategory').valid()) {

            if ($("#DescAr").val() == "" || $("#DescEn").val() == "" || $("#hdfAttachments").val() == "0" || $("#hdfFileAttachments").val() == "0") {
                warningAlert("يجب ادخال كل البيانات");
                $('#btnSaveCategory').removeAttr('disabled');
                return false;
            }
            var form = $('#frmCategory');
            var actionUrl = form.attr('action');
            var sendData = form.serialize() + '&oldImage=' + imageSrcId;
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    alert("تم الحفظ بنجاح");
                    setTimeout(function () { window.location = "/Category/Index"; }, 1000);
                }
                else if (res == -2)
                    warningAlert("تاريخ البدايه لازم اكبر من تاريخ اليوم");
                else if (res == -3)
                    warningAlert("تاريخ النهايه لازم اكبر من تاريخ البداية");
                else
                    warningAlert("حصل خطأ اثناء الحفظ");

            });
        }
        else
            $('#btnSaveCategory').removeAttr('disabled');



    });
});
