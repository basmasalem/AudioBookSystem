$(function () {

    $('#btnSaveSetting').click(function (evt) {
        debugger;
        $('#btnSaveSetting').attr('disabled', 'disabled');
        if ($('#frmSetting').valid()) {
            var form = $('#frmSetting');
            var actionUrl = form.attr('action');
            var sendData = form.serialize();
            $.post(actionUrl, sendData).done(function (res) {
                if (res == 1) {
                    window.location = "/Setting/Index";
                }
                else
                    warningAlert("حصل خطأ اثناء الحفظ");

            });
        }
        else
            $('#btnSaveSetting').removeAttr('disabled');



    });
});


