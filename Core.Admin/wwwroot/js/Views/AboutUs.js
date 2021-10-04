$(function () {

    $('#btnSaveAboutUs').click(function (evt) {
        debugger;
        $('#btnSaveAboutUs').attr('disabled', 'disabled');
        if ($('#frmAboutUs').valid()) {

            if ($("#AboutUsAr").val() == "" || $("#AboutUsEn").val() == "" || $("#hdfAttachments").val() == "0") {
                warningAlert("يجب ادخال كل البيانات");
                $('#btnSaveAboutUs').removeAttr('disabled');
                return false;
            }
            var form = $('#frmAboutUs');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    window.location = "/AboutUs/Index";
                }
                else
                    warningAlert("حصل خطأ اثناء الحفظ");

            });
        }
        else
            $('#btnSaveAboutUs').removeAttr('disabled');



    });
});


