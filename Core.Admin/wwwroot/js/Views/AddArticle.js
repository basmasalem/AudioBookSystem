$(function () {

    $('#btnSaveArticle').click(function (evt) {
        debugger;
        $('#btnSaveArticle').attr('disabled', 'disabled');
        if ($('#frmAddArticle').valid()) {

            if ($("#DescAr").val() == "" || $("#DescEn").val() == "" || $("#hdfAttachments").val() == "0" ) {
                warningAlert("يجب ادخال كل البيانات");
                $('#btnSaveArticle').removeAttr('disabled');
                return false;
            }
            var form = $('#frmAddArticle');
            var actionUrl = form.attr('action');
            var sendData = form.serialize() + '&oldImage=' + imageSrcId;
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    alert("تم الحفظ بنجاح");
                    setTimeout(function () { window.location = "/Article/Index"; }, 1000);
                }
                else
                    warningAlert("حصل خطأ اثناء الحفظ");

            });
        }
        else
            $('#btnSaveArticle').removeAttr('disabled');



    });
});
